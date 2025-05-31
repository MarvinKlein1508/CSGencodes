using CSGencodes.Core.Models;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace CSGencodes.Components;

public partial class DisplaySticker
{
    [Parameter, EditorRequired, DisallowNull]
    public Sticker? Sticker { get; set; }
    [Parameter, EditorRequired, DisallowNull]
    public EventCallback<Sticker> OnClick { get; set; }


    public string GetRarityCSS()
    {
        if (Sticker is null)
        {
            return string.Empty;
        }

        return Sticker.Rarity switch
        {
            ItemRarity.Rare => "rarity-rare",
            ItemRarity.Mythical => "rarity-mythical",
            ItemRarity.Legendary => "rarity-legendary",
            ItemRarity.Ancient => "rarity-ancient",
            ItemRarity.Common => "rarity-common",
            ItemRarity.Uncommon => "rarity-uncommon",
            ItemRarity.Immortal => "rarity-immortal",
            ItemRarity.Unknown => "rarity-unknown",
            _ => string.Empty,
        };
    }
}