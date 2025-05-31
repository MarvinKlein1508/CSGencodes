using ItemsParser.Shared;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ItemsParser;
public static class StickerKits
{
    private static readonly string _items_game;
    private static readonly List<string> _stickerKitBlocks;
    private static readonly List<StickerKit> _stickerKits = [];
    static StickerKits()
    {
        string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "items_game.txt");
        _items_game = File.ReadAllText(filename);
        _stickerKitBlocks = ExtractAllStickerKitsBlocks(_items_game);

        foreach (var block in _stickerKitBlocks)
        {
            var kits = ParseStickerKitEntries(block);
            _stickerKits.AddRange(kits);
        }
    }

    public static void GenerateStickerCollections()
    {
        Dictionary<string, List<Sticker>> stickerCollections = new();

        // Step 1 cast cs2 items into valid objects
        Console.WriteLine("Parsing sticker kits...");
        int i = 0;
        foreach (var item in _stickerKits)
        {
            i++;
            Console.Write("{0}/{1}\r", i, _stickerKits.Count);
            if (item.Id is 0 || item.StickerMaterial.EndsWith("_graffiti") || item.StickerMaterial == string.Empty)
            {
                // Skip fallback sticker and graffitis and patches (empty)
                continue;
            }

            // Fix CS broken names
            if (item.ItemName == "#StickerKit_dhw2014_dignitas_gold")
            {
                item.ItemName = "#StickerKit_dhw2014_teamdignitas_gold";
            }

            string stickerName = Translation.GetTranslation(item.ItemName);
            ItemRarity rarity = item.ItemRarity switch
            {
                "rare" => ItemRarity.Rare,
                "mythical" => ItemRarity.Mythical,
                "legendary" => ItemRarity.Legendary,
                "ancient" => ItemRarity.Ancient,
                "common" => ItemRarity.Common,
                "uncommon" => ItemRarity.Uncommon,
                "immortal" => ItemRarity.Immortal,
                _ => ItemRarity.Unknown,
            };



            int index = item.StickerMaterial.IndexOf('/');
            string collection = item.StickerMaterial[..index];

            Sticker sticker = new()
            {
                Name = stickerName,
                Rarity = rarity,
                StickerId = item.Id,
                Image = $"/assets/img/items/stickers/{item.StickerMaterial}_png.png",
                Collection = collection,
                BuffStickerId = null,
            };

            if (stickerCollections.TryGetValue(collection, out List<Sticker>? value))
            {
                value.Add(sticker);
            }
            else
            {
                stickerCollections[collection] = [sticker];
            }

        }

        Console.WriteLine("Generate sticker collections...");

        if (!Directory.Exists("Output"))
        {
            Directory.CreateDirectory("Output");
        }

        foreach (var collection in stickerCollections)
        {
            string filename = Path.Combine("Output", $"{collection.Key}.json");

            string json = JsonSerializer.Serialize(collection.Value, new JsonSerializerOptions
            {
                WriteIndented = true,
            });

            File.WriteAllText(filename, json);
        }
    }
    private static List<string> ExtractAllStickerKitsBlocks(string input)
    {
        var results = new List<string>();
        var regex = new Regex(@"""sticker_kits""\s*\{((?>[^{}]+|\{(?<c>)|\}(?<-c>))*)(?(c)(?!))\}", RegexOptions.Singleline);
        var matches = regex.Matches(input);

        foreach (Match match in matches)
        {
            results.Add(match.Value.Trim());
        }

        return results;
    }

    private static List<StickerKit> ParseStickerKitEntries(string stickerKitsBlock)
    {
        var kits = new List<StickerKit>();

        var entryRegex = new Regex(@"""(\d+)""\s*\{((?>[^{}]+|\{(?<c>)|\}(?<-c>))*)(?(c)(?!))\}", RegexOptions.Singleline);
        var matches = entryRegex.Matches(stickerKitsBlock);

        foreach (Match match in matches)
        {
            int id = int.Parse(match.Groups[1].Value);
            string content = match.Groups[2].Value;
            int? tournamentEventId = null;
            string tournamentIdText = ExtractField(content, "tournament_event_id");
            if (int.TryParse(tournamentIdText, out int parsedTournamentId))
            {
                tournamentEventId = parsedTournamentId;
            }

            var kit = new StickerKit
            {
                Id = id,
                Name = ExtractField(content, "name"),
                ItemName = ExtractField(content, "item_name"),
                DescriptionString = ExtractField(content, "description_string"),
                StickerMaterial = ExtractField(content, "sticker_material"),
                ItemRarity = ExtractField(content, "item_rarity"),
                TournamentEventId = tournamentEventId
            };

            kits.Add(kit);
        }

        return kits;
    }

    private static string ExtractField(string content, string fieldName)
    {
        var regex = new Regex(@"""" + fieldName + @"""\s*""([^""]*)""", RegexOptions.Singleline);
        var match = regex.Match(content);
        return match.Success ? match.Groups[1].Value : string.Empty;
    }
    private class StickerKit
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string ItemName { get; set; }
        public required string DescriptionString { get; set; }
        public required string StickerMaterial { get; set; }
        public required string ItemRarity { get; set; }
        public required int? TournamentEventId { get; set; }
    }
}


