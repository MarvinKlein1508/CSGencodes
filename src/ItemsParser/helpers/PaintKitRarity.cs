using System.Text.RegularExpressions;

namespace ItemsParser.helpers;
internal static class PaintKitRarity
{
    private static Dictionary<string, string> _rarities;
    static PaintKitRarity()
    {
        _rarities = ParseAllPaintKitsRarity(ItemsGameData.ItemsGame);
    }

    public static string GetRarity(string paintKitName)
    {
        var tmp = _rarities;
        return tmp[paintKitName];
    }
    private static Dictionary<string, string> ParseAllPaintKitsRarity(string input)
    {
        var dict = new Dictionary<string, string>();

        var blockRe = new Regex(
            @"""paint_kits_rarity""\s*\{(?<body>(?>[^{}]+|{(?<c>)|}(?<-c>))*(?(c)(?!)))\}",
            RegexOptions.Singleline);

        foreach (Match m in blockRe.Matches(input))
        {
            string body = m.Groups["body"].Value;

            foreach (Match kv in Regex.Matches(
                         body,
                         @"""(?<key>[^""]+)""\s*""(?<val>[^""]+)""",
                         RegexOptions.Multiline))
            {
                dict[kv.Groups["key"].Value] = kv.Groups["val"].Value;
            }
        }

        return dict;
    }
}
