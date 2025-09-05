using System.Text.RegularExpressions;

namespace ItemsParser.helpers;
internal static class PaintKits
{
    private static readonly List<string> _paintKitBlocks;
    private static readonly List<PaintKit> _paintKits = [];

    static PaintKits()
    {
        _paintKitBlocks = ExtractAllPaintKitsBlocks(ItemsGameData.ItemsGame);

        foreach (var block in _paintKitBlocks)
        {
            var kits = ParsePaintKitEntries(block);
            _paintKits.AddRange(kits);
        }
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
    private static string ExtractField(string content, string fieldName)
    {
        var regex = new Regex(@"""" + fieldName + @"""\s*""([^""]*)""", RegexOptions.Singleline);
        var match = regex.Match(content);
        return match.Success ? match.Groups[1].Value : string.Empty;
    }
    public static PaintKit GetPaintKitByName(string name)
    {
        return _paintKits.First(x => x.Name == name);
    }
    public static (string name, int weapon_id, string econ_name) GetWeaponType(string key)
    {
        // Key: [hy_mesh_safetyorange]weapon_tec9
        var keySplitted = key.Split(']');

        if (keySplitted.Length == 2)
        {
            string weaponPart = keySplitted[1];

            return weaponPart switch
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
                "weapon_elite" => ("Dual Berettas", 2, "elite"),
                "weapon_sg556" => ("SG 553", 39, "sg556"),
                "weapon_sawedoff" => ("Sawed-Off", 29, "sawedoff"),
                "weapon_mp5sd" => ("MP5-SD", 23, "mp5sd"),
                "weapon_revolver" => ("R8 Revolver", 64, "revolver"),
                "weapon_m249" => ("M249", 14, "m249"),
                "weapon_g3sg1" => ("G3SG1", 11, "g3sg1"),
                "weapon_bizon" => ("PP-Bizon", 26, "bizon"),
                "weapon_mp7" => ("MP7", 33, "mp7"),
                "weapon_scar20" => ("SCAR-20", 38, "scar20"),
                _ => throw new NotImplementedException($"Weapon {weaponPart} has not been implemented"),
            };
        }

        return (string.Empty, 0, string.Empty);
    }
}

internal class PaintKit
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