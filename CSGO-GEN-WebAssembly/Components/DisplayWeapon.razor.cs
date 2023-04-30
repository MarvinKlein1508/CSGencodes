using Microsoft.AspNetCore.Components;
using CSGO_GEN.Core.Models;
using System.Diagnostics.CodeAnalysis;

namespace CSGO_GEN_WebAssembly.Components
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

            return Weapon.rarity switch
            {
                "Consumer" => "rarity-consumer",
                "Industrial" => "rarity-industrial",
                "Milspec" => "rarity-milspec",
                "Restricted" => "rarity-restricted",
                "Classified" => "rarity-classified",
                "Covert" => "rarity-covert",
                _ => string.Empty,
            };
        }

    }
}