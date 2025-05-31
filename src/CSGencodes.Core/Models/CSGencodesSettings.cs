using CSGencodes.Core.Filters;

namespace CSGencodes.Core.Models;

public class CSGencodesSettings
{
    public bool MinMaxFloats { get; set; } = false;
    public bool EnableOffsets { get; set; } = true;
    public StickerFilter StickerFilter { get; set; } = new();
    public WeaponFilter WeaponFilter { get; set; } = new();
}
