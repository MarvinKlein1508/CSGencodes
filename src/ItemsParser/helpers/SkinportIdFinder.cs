using CSGencodes.Core.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace JsonModelCreator;
internal static class SkinportIdFinder
{
    private static readonly List<SkinportStickerSearchItem> _skinportStickerSearchItems;

    static SkinportIdFinder()
    {
        using var reader = new StreamReader("data/skinport/sticker_ids.csv");
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<SkinportStickerSearchItemMap>();
        _skinportStickerSearchItems = csv.GetRecords<SkinportStickerSearchItem>().ToList();
    }
    public static string? GetSkinportId(Sticker sticker)
    {
        return _skinportStickerSearchItems.FirstOrDefault(x => x.Name.Equals(sticker.Name))?.StickerId;
    }
}

internal class SkinportStickerSearchItem
{

    public string StickerId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

internal class SkinportStickerSearchItemMap : ClassMap<SkinportStickerSearchItem>
{
    public SkinportStickerSearchItemMap()
    {
        Map(m => m.StickerId).Name("sticker_id");
        Map(m => m.Name).Name("market_hash_name")
            .Convert(row =>
            {
                var raw = row.Row.GetField("market_hash_name");
                return raw!.Replace("Sticker | ", "").Trim();
            });
    }
}