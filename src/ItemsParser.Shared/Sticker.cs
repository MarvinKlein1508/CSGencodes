namespace ItemsParser.Shared;
public class Sticker
{
    public required string Name { get; set; }
    public required int StickerId { get; set; }
    public required ItemRarity Rarity { get; set; }
    public required string Image { get; set; }
    public required string Collection { get; set; }
    public required int? BuffStickerId { get; set; }
}
