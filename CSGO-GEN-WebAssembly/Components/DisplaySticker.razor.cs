using Microsoft.AspNetCore.Components;
using CSGO_GEN.Core.Models;
using System.Diagnostics.CodeAnalysis;

namespace CSGO_GEN_WebAssembly.Components
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
                _ => string.Empty,
            };
        }
    }
}