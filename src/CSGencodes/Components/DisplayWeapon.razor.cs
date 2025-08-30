using CSGencodes.Core.Models;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace CSGencodes.Components
{
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
                "Consumer" => "rarity-consumer",
                "Industrial" => "rarity-industrial",
                "Milspec" => "rarity-milspec",
                "Restricted" => "rarity-restricted",
                "Classified" => "rarity-classified",
                "Covert" => "rarity-covert",
                "Contraband" => "rarity-contraband",
                _ => string.Empty,
            };
        }

    }
}