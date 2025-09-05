using CSGencodes.Core.Models;
using ItemsParser.helpers;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ItemsParser.workers;
internal static class CollectionWorker
{
    private const string OUTPUT_DIR = "output";
    private const string OUTPUT_COLLECTION_DIR = "collections";
    private const string THE_HUNTSMAN_COLLECTION = "set_community_3";

    private const int FLOAT_DIVIDER = 1_000_000;

    /// <summary>
    /// This array contains item sets which are not weapon item sets and should be ignored
    /// </summary>
    private static readonly string[] _blockedItemSets = ["#CSGO_set_op9_characters", "#CSGO_set_op10_characters", "#CSGO_set_op11_characters"];


    private static readonly List<string> _itemSetBlocks;

    private static readonly List<ItemSet> _itemSets = [];
    static CollectionWorker()
    {
        _itemSetBlocks = ExtractAllItemSetsBlocks(ItemsGameData.ItemsGame);

        foreach (var block in _itemSetBlocks)
        {
            var itemSets = ParseItemSets(block);
            _itemSets.AddRange(itemSets);
        }
    }

    public static void GenerateWeaponCollections()
    {
        Dictionary<string, List<Weapon>> weaponCollections = new();

        Console.WriteLine("Parsing collections...");
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

            weaponCollections.Add(itemSet.Id, []);

            foreach (var item in itemSet.Items)
            {
                string key = item.Key;
                string paintKitName = key.Split('[', ']')[1];
                var paintKit = PaintKits.GetPaintKitByName(paintKitName);

                (string weaponName, int weapon_id, string econ_name) = PaintKits.GetWeaponType(paintKit);

                var rarity = ClientLootList.GetRarity(paintKit.Name);

                string skinName = Translation.GetTranslation(paintKit.DescriptionTag);

                if (paintKit.Id is 1119)
                {
                    skinName = "Gamma Doppler (Emerald)";
                }
                else if (paintKit.Id is 1120)
                {
                    skinName = "Gamma Doppler (Phase 1)";
                }
                else if (paintKit.Id is 1121)
                {
                    skinName = "Gamma Doppler (Phase 2)";
                }
                else if (paintKit.Id is 1122)
                {
                    skinName = "Gamma Doppler (Phase 3)";
                }
                else if (paintKit.Id is 1123)
                {
                    skinName = "Gamma Doppler (Phase 4)";
                }

                var weapon = new Weapon
                {
                    Name = $"{weaponName} | {skinName}",
                    WeaponId = weapon_id,
                    PaintKitId = paintKit.Id,
                    MaxWear = paintKit.WearRemapMax / FLOAT_DIVIDER,
                    MinWear = paintKit.WearRemapMin / FLOAT_DIVIDER,
                    Rarity = rarity,
                    Collection = collection,
                    Image = $"/assets/img/items/weapons/{itemSet.Id}/weapon_{econ_name}_{paintKitName}_light_png.png"
                };

                weaponCollections[itemSet.Id].Add(weapon);
            }
        }

        // Add missing items
        weaponCollections[THE_HUNTSMAN_COLLECTION].Add(new Weapon
        {
            Name = "M4A4 | Howl",
            WeaponId = 16,
            PaintKitId = 309,
            MinWear = 0,
            MaxWear = 0.4m,
            Rarity = ItemRarity.Immortal,
            Collection = "The Huntsman Collection",
            Image = "/assets/img/items/weapons/set_community_3/weapon_m4a1_cu_m4a1_howling_light_png.png"
        });

        Console.WriteLine("Generate collection json files...");

        if (!Directory.Exists(OUTPUT_DIR))
        {
            Directory.CreateDirectory(OUTPUT_DIR);
        }

        string collectionDir = Path.Combine(OUTPUT_DIR, OUTPUT_COLLECTION_DIR);

        if (!Directory.Exists(collectionDir))
        {
            Directory.CreateDirectory(collectionDir);
        }

        foreach (var collection in weaponCollections)
        {
            string filename = Path.Combine(collectionDir, $"{collection.Key}.json");

            string json = JsonSerializer.Serialize(collection.Value, new JsonSerializerOptions
            {
                WriteIndented = true,
            });

            File.WriteAllText(filename, json);
        }
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



    private class ItemSet
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCollection { get; set; }
        public Dictionary<string, string> Items { get; set; } = [];
    }
}
