using CSGencodes.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static CEconItemPreviewDataBlock.Types;

namespace ItemsParser;
internal static class PaintKits
{
    private const string OUTPUT_DIR = "output";
    private const string OUTPUT_COLLECTION_DIR = "collections";

    private const int FLOAT_DIVIDER = 1_000_000;

    /// <summary>
    /// This array contains item sets which are not weapon item sets and should be ignored
    /// </summary>
    private static readonly string[] _blockedItemSets = ["#CSGO_set_op9_characters", "#CSGO_set_op10_characters", "#CSGO_set_op11_characters"];

    private static readonly string _items_game;
    private static readonly List<string> _paintKitBlocks;
    private static readonly List<string> _itemSetBlocks;
    private static readonly List<PaintKit> _paintKits = [];
    private static readonly List<ItemSet> _itemSets = [];
    static PaintKits()
    {
        string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "items_game.txt");
        _items_game = File.ReadAllText(filename);
        _paintKitBlocks = ExtractAllPaintKitsBlocks(_items_game);

        foreach (var block in _paintKitBlocks)
        {
            var kits = ParsePaintKitEntries(block);
            _paintKits.AddRange(kits);
        }

        _itemSetBlocks = ExtractAllItemSetsBlocks(_items_game);

        foreach (var block in _itemSetBlocks)
        {
            var itemSets = ParseItemSets(block);
            _itemSets.AddRange(itemSets);
        }
    }

    public static void GeneratePaintKitCollections()
    {
        Dictionary<string, List<Weapon>> weaponCollections = new();

        // Step 1 cast cs2 items into valid objects
        Console.WriteLine("Parsing paint kits...");
        int i = 0;

        foreach (var itemSet in _itemSets)
        {
            i++;
            Console.Write("{0}/{1}\r", i, _itemSets.Count);

            if (_blockedItemSets.Contains(itemSet.Name))
            {
                continue;
            }

            var collection = Translation.GetTranslation(itemSet.Name);

            weaponCollections.Add(collection, []);

            foreach (var item in itemSet.Items)
            {
                string key = item.Key;
                string paintKitId = key.Split('[', ']')[1];
                var paintKit = _paintKits.First(x => x.Name == paintKitId);

                (string weaponName, int weapon_id, string econ_name) = GetWeaponType(paintKit);

                var weapon = new Weapon
                {
                    name = $"{weaponName} | {Translation.GetTranslation(paintKit.DescriptionTag)}",
                    weapon_id = weapon_id,
                    gen_id = paintKit.Id,
                    max_wear = paintKit.WearRemapMax / FLOAT_DIVIDER,
                    min_wear = paintKit.WearRemapMin / FLOAT_DIVIDER
                };

                weaponCollections[collection].Add(weapon);
            }
        }

        Console.WriteLine(weaponCollections.Count);
    }

    private static List<string> ExtractAllPaintKitsBlocks(string input)
    {
        var results = new List<string>();
        var regex = new Regex(@"""paint_kits""\s*\{((?>[^{}]+|\{(?<c>)|\}(?<-c>))*)(?(c)(?!))\}", RegexOptions.Singleline);
        var matches = regex.Matches(input);

        foreach (Match match in matches)
        {
            results.Add(match.Value.Trim());
        }

        return results;
    }

    private static List<string> ExtractAllItemSetsBlocks(string input)
    {
        var results = new List<string>();
        var regex = new Regex(@"""item_sets""\s*\{((?>[^{}]+|\{(?<c>)|\}(?<-c>))*)(?(c)(?!))\}", RegexOptions.Singleline);
        var matches = regex.Matches(input);

        foreach (Match match in matches)
        {
            results.Add(match.Value.Trim());
        }

        return results;
    }
    private static List<PaintKit> ParsePaintKitEntries(string stickerKitsBlock)
    {
        var kits = new List<PaintKit>();

        var entryRegex = new Regex(@"""(\d+)""\s*\{((?>[^{}]+|\{(?<c>)|\}(?<-c>))*)(?(c)(?!))\}", RegexOptions.Singleline);
        var matches = entryRegex.Matches(stickerKitsBlock);

        foreach (Match match in matches)
        {
            int id = int.Parse(match.Groups[1].Value);
            string content = match.Groups[2].Value;
            decimal wearRemapMin, wearRemapMax;
            string wearRemapMinText = ExtractField(content, "wear_remap_min");
            string wearRemapMaxText = ExtractField(content, "wear_remap_max");

            _ = decimal.TryParse(wearRemapMinText, out wearRemapMin);
            _ = decimal.TryParse(wearRemapMaxText, out wearRemapMax);


            var kit = new PaintKit
            {
                Id = id,
                Name = ExtractField(content, "name"),
                DescriptionString = ExtractField(content, "description_string"),
                DescriptionTag = ExtractField(content, "description_tag"),
                CompositeMaterialPath = ExtractField(content, "composite_material_path"),
                Style = ExtractField(content, "style"),
                WearRemapMin = wearRemapMin,
                WearRemapMax = wearRemapMax
            };

            kits.Add(kit);
        }

        return kits;
    }

    private static List<ItemSet> ParseItemSets(string input)
    {
        var results = new List<ItemSet>();

        // 1) item_sets-Root balanciert extrahieren
        var root = Regex.Match(
            input,
            @"""item_sets""\s*\{(?<root>(?>[^{}]+|{(?<c>)|}(?<-c>))*(?(c)(?!)))\}",
            RegexOptions.Singleline);

        if (!root.Success)
            return results;

        string rootBody = root.Groups["root"].Value;

        // 2) Alle direkten Sets darin balanciert finden
        var setMatches = Regex.Matches(
            rootBody,
            @"""(?<id>[^""]+)""\s*\{(?<body>(?>[^{}]+|{(?<c>)|}(?<-c>))*(?(c)(?!)))\}",
            RegexOptions.Singleline);

        foreach (Match m in setMatches)
        {
            var set = new ItemSet();
            set.Id = m.Groups["id"].Value;

            string body = m.Groups["body"].Value;

            // name
            set.Name = Regex.Match(body, @"""name""\s*""([^""]+)""").Groups[1].Value;

            // description
            set.Description = Regex.Match(body, @"""set_description""\s*""([^""]+)""").Groups[1].Value;

            // is_collection
            var isColl = Regex.Match(body, @"""is_collection""\s*""([^""]+)""").Groups[1].Value;
            set.IsCollection = isColl == "1";

            // items (balanciert, falls innerhalb nochmal {...} auftaucht)
            var itemsBlockMatch = Regex.Match(
                body,
                @"""items""\s*\{(?<items>(?>[^{}]+|{(?<c>)|}(?<-c>))*(?(c)(?!)))\}",
                RegexOptions.Singleline);

            if (itemsBlockMatch.Success)
            {
                var itemLines = Regex.Matches(itemsBlockMatch.Groups["items"].Value,
                                              @"""([^""]+)""\s*""([^""]+)""");
                foreach (Match im in itemLines)
                {
                    string key = im.Groups[1].Value;
                    string value = im.Groups[2].Value;
                    set.Items[key] = value;
                }
            }

            results.Add(set);
        }

        return results;
    }
    private static string ExtractField(string content, string fieldName)
    {
        var regex = new Regex(@"""" + fieldName + @"""\s*""([^""]*)""", RegexOptions.Singleline);
        var match = regex.Match(content);
        return match.Success ? match.Groups[1].Value : string.Empty;
    }

    private static (string name, int weapon_id, string econ_name) GetWeaponType(PaintKit entry)
    {
        string name = entry.Name;
        string pattern = $@"\[{Regex.Escape(name)}\]([a-zA-Z0-9_]+)";
        var match = Regex.Match(_items_game, pattern);

        if (match.Success)
        {
            string weapon_type = match.Groups[1].Value;


            return weapon_type switch
            {
                "weapon_hkp2000" => ("P2000", 32, "hkp2000"),
                "weapon_xm1014" => ("XM1014", 25, "xm1014"),
                "weapon_taser" => ("Zeus", 31, "taser"),
                "weapon_famas" => ("FAMAS", 10, "famas"),
                "weapon_galilar" => ("Galil AR", 13, "galilar"),
                "weapon_usp_silencer" => ("USP-S", 61, "usp_silencer"),
                "weapon_ssg08" => ("SSG 08", 40, "ssg08"),
                "weapon_mag7" => ("MAG-7", 27, "mag7"),
                "weapon_deagle" => ("Desert Eagle", 1, "deagle"),
                "weapon_p90" => ("P90", 19, "p90"),
                "weapon_nova" => ("Nova", 35, "nova"),
                "weapon_mp9" => ("MP9", 34, "mp9"),
                "weapon_ump45" => ("UMP-45", 24, "ump45"),
                "weapon_cz75a" => ("CZ75-Auto", 63, "cz75a"),
                "weapon_aug" => ("AUG", 8, "aug"),
                "weapon_glock" => ("Glock-18", 4, "glock"),
                "weapon_mac10" => ("MAC-10", 17, "mac10"),
                "weapon_awp" => ("AWP", 9, "awp"),
                "weapon_ak47" => ("AK-47", 7, "ak47"),
                "weapon_m4a1" => ("M4A4", 16, "m4a1"),
                "weapon_p250" => ("P250", 36, "p250"),
                "weapon_tec9" => ("Tec-9", 30, "tec9"),
                "weapon_m4a1_silencer" => ("M4A1-S", 60, "m4a1_silencer"),
                "weapon_negev" => ("Negev", 28, "negev"),
                "weapon_fiveseven" => ("Five-SeveN", 3, "fiveseven"),
                "weapon_elite" => ("Dual Berettas", 2, "elite_gs"),
                "weapon_sg556" => ("SG 553", 39, "sg556"),
                "weapon_sawedoff" => ("Sawed-Off", 29, "sawedoff"),
                "weapon_mp5sd" => ("MP5-SD", 23, "mp5sd"),
                "weapon_revolver" => ("R8 Revolver", 64, "revolver"),
                "weapon_m249" => ("M249", 14, "m249"),
                "weapon_g3sg1" => ("G3SG1", 11, "g3sg1"),
                "weapon_bizon" => ("PP-Bizon", 26, "bizon"),
                "weapon_mp7" => ("MP7", 33, "mp7"),
                "weapon_scar20" => ("SCAR-20", 38, "scar20"),
                _ => throw new NotImplementedException($"Weapon {weapon_type} has not been implemented"),
            };
        }

        Console.WriteLine($"Weapon for \"{name}\" could not be found.");
        return (string.Empty, 0, string.Empty);
    }

    private class PaintKit
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DescriptionString { get; set; } = string.Empty;
        public string DescriptionTag { get; set; } = string.Empty;
        public string Style { get; set; } = string.Empty;
        public decimal WearRemapMin { get; set; }
        public decimal WearRemapMax { get; set; }
        public string CompositeMaterialPath { get; set; } = string.Empty;
    }

    private class ItemSet
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCollection { get; set; }
        public Dictionary<string, string> Items { get; set; } = [];
    }
}
