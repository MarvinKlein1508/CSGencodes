using CSGencodes.Core.Models;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace CSGencodes.Components;

public partial class DisplayWeapon
{
    [Parameter, EditorRequired, DisallowNull]
    public Weapon? Weapon { get; set; }
    [Parameter, EditorRequired, DisallowNull]
    public EventCallback<Weapon> OnClick { get; set; }


    public string GetRarityCSS()
    {
        if (Weapon is null)
        {
            return string.Empty;
        }

        return Weapon.Rarity switch
        {
            ItemRarity.Common or ItemRarity.Unknown => "rarity-consumer",
            ItemRarity.Uncommon => "rarity-industrial",
            ItemRarity.Rare => "rarity-milspec",
            ItemRarity.Mythical => "rarity-restricted",
            ItemRarity.Legendary => "rarity-classified",
            ItemRarity.Ancient => "rarity-covert",
            ItemRarity.Immortal => "rarity-contraband",
            _ => string.Empty,
        };
    }

}