namespace CSGencodes.Core.Models;

public class Sticker : IGenable
{
    public string Name { get; set; } = string.Empty;
    public int StickerId { get; set; }
    public ItemRarity Rarity { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Collection { get; set; } = string.Empty;
    public int GetGenId()
    {
        return StickerId;
    }
}

public class AppliedSticker : Sticker
{
    public decimal Scratched { get; set; }
    public decimal Rotation { get; set; }

    public float OffsetX { get; set; }
    public float OffsetY { get; set; }
    public int PosId { get; set; }

    public AppliedSticker(Sticker sticker, int posId)
    {
        Name = sticker.Name;
        StickerId = sticker.StickerId;
        Collection = sticker.Collection;
        Rarity = sticker.Rarity;
        Image = sticker.Image;
        PosId = posId;
    }
}
