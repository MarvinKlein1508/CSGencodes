using CSGO_GEN.Core.Filters;
using CSGO_GEN.Core.Models;

namespace CSGO_GEN_WebAssembly.Pages
{
    public partial class Index
    {
        private decimal _float = 0.01m;
        private int _pattern = 661;

        public WeaponFilter WeaponFilter { get; set; } = new();
        public StickerFilter StickerFilter { get; set; } = new();
        public Weapon? SelectedWeapon { get; set; }

        public List<AppliedSticker> SelectedStickers { get; set; } = new();

        
        public decimal Float
        {
            get => _float;
            set
            {

                decimal min_float = SelectedWeapon?.min_wear ?? 0m;
                decimal max_float = SelectedWeapon?.max_wear ?? 1m;

                if (value <= min_float)
                {
                    _float = min_float;
                }
                else if (value > max_float)
                {
                    _float = max_float;
                }
                else
                {
                    _float = value;
                }
            }
        }

        public int Pattern
        {
            get => _pattern;
            set
            {
                if (value < 0)
                {
                    _pattern = 0;
                }
                else if (value > 1000)
                {
                    _pattern = 1000;
                }
                else
                {
                    _pattern = value;
                }
            }
        }
        private void OnWeaponClicked(Weapon weapon)
        {
            SelectedWeapon = weapon;
            Float = Float;
        }

        private void OnStickerClicked(Sticker sticker)
        {
            if (SelectedStickers.Count < 5)
            {
                SelectedStickers.Add(new AppliedSticker(sticker));
            }
        }
    }
}