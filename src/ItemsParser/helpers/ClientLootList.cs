using ItemsParser.helpers;
using System.Text.RegularExpressions;

namespace ItemsGameParser;
internal static class ClientLootList
{
    internal static Dictionary<string, List<string>> _lootlist = [];
    static ClientLootList()
    {
        ParseClientLootLists(ItemsGameData.ItemsGame);
    }
    internal static void ParseClientLootLists(string input)
    {
        var allClientLootListBlocks = ExtractClientLootListsBlocks(input);
        _lootlist = new Dictionary<string, List<string>>();

        foreach (var block in allClientLootListBlocks)
        {
            var match = Regex.Match(block, @"""client_loot_lists""\s*\{([\s\S]*)\}\s*$");
            if (match.Success)
            {
                var singleMap = ParseNamedLootLists(match.Groups[1].Value);
                foreach (var pair in singleMap)
                {
                    _lootlist[pair.Key] = pair.Value;
                }
            }
        }
    }
    internal static string GetRarity(string itemName)
    {
        if (itemName is "cu_retribution" or "cu_p90_scorpius" or "am_nitrogen")
        {
            return "Milspec";
        }
        else if (itemName is "cu_mac10_decay" or "cu_xray_p250" or "hy_labrat_mp5")
        {
            return "Restricted";
        }
        else if (itemName is "cu_usp_spitfire")
        {
            return "Classified";
        }

        foreach (var list in _lootlist)
        {
            string lootListName = list.Key;

            foreach (var item in list.Value)
            {
                if (item.StartsWith($"[{itemName}]"))
                {
                    if (lootListName.EndsWith("_common"))
                    {
                        return "Consumer";
                    }
                    else if (lootListName.EndsWith("_uncommon"))
                    {
                        return "Industrial";
                    }
                    else if (lootListName.EndsWith("_rare"))
                    {
                        return "Milspec";
                    }
                    else if (lootListName.EndsWith("_mythical"))
                    {
                        return "Restricted";
                    }
                    else if (lootListName.EndsWith("_legendary"))
                    {
                        return "Classified";
                    }
                    else if (lootListName.EndsWith("_ancient"))
                    {
                        return "Covert";
                    }
                    else
                    {
                        return "Contraband";
                    }
                }
            }
        }

        throw new Exception($"Could not figure out rarity for: {itemName}");
    }
    private static List<string> ExtractClientLootListsBlocks(string input)
    {
        var blocks = new List<string>();
        int pos = 0;

        while (pos < input.Length)
        {
            // Suche nach "client_loot_lists"
            int start = input.IndexOf("\"client_loot_lists\"", pos);
            if (start == -1) break;

            // Finde erste öffnende Klammer danach
            int openBrace = input.IndexOf('{', start);
            if (openBrace == -1) break;

            int braceCount = 1;
            int i = openBrace + 1;

            while (i < input.Length && braceCount > 0)
            {
                if (input[i] == '{') braceCount++;
                else if (input[i] == '}') braceCount--;
                i++;
            }

            // Extrahiere den vollständigen Block
            string fullBlock = input.Substring(start, i - start);
            blocks.Add(fullBlock);

            // Weiter suchen hinter diesem Block
            pos = i;
        }

        return blocks;
    }
    private static Dictionary<string, List<string>> ParseNamedLootLists(string clientLootListsBlockContent)
    {
        var result = new Dictionary<string, List<string>>();
        int pos = 0;

        while (pos < clientLootListsBlockContent.Length)
        {
            var match = Regex.Match(clientLootListsBlockContent.Substring(pos), @"""([^""]+)""\s*\{", RegexOptions.Singleline);
            if (!match.Success) break;

            string listName = match.Groups[1].Value;
            int blockStart = pos + match.Index + match.Length;

            int braceCount = 1;
            int i = blockStart;
            while (i < clientLootListsBlockContent.Length && braceCount > 0)
            {
                if (clientLootListsBlockContent[i] == '{') braceCount++;
                else if (clientLootListsBlockContent[i] == '}') braceCount--;
                i++;
            }

            string blockBody = clientLootListsBlockContent.Substring(blockStart, i - blockStart - 1);
            var items = new List<string>();

            var itemMatches = Regex.Matches(blockBody, @"""([^""]+)""\s*""1""");
            foreach (Match item in itemMatches)
            {
                items.Add(item.Groups[1].Value);
            }

            result[listName] = items;
            pos += match.Index + (i - blockStart);
        }

        return result;
    }
}
