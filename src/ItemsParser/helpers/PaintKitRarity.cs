using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        return _rarities[paintKitName];
    }
    private static Dictionary<string, string> ParseAllPaintKitsRarity(string input)
    {
        var dict = new Dictionary<string, string>();

        // Alle "paint_kits_rarity"-Blöcke (balancierte Klammern) finden
        var blockRe = new Regex(
            @"""paint_kits_rarity""\s*\{(?<body>(?>[^{}]+|{(?<c>)|}(?<-c>))*(?(c)(?!)))\}",
            RegexOptions.Singleline);

        foreach (Match m in blockRe.Matches(input))
        {
            string body = m.Groups["body"].Value;

            // Alle "key" "value"-Paare aus dem Block holen
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
