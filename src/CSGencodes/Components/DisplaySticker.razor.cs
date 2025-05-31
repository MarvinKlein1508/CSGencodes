using CSGencodes.Core.Models;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace CSGencodes.Components
{
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

            return Sticker.rarity switch
            {
                "HighGrade" => "rarity-highgrade",
                "Remarkable" => "rarity-remarkable",
                "Exotic" => "rarity-exotic",
                "Extraordinary" => "rarity-extraordinary",
                "Contraband" => "rarity-contraband",
                _ => string.Empty,
            };
        }
    }
}