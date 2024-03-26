using CSGencodes.Core.Filters;
using CSGencodes.Core.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Components;
using System.Text;
using System.Web;
using System.Globalization;

namespace CSGencodes.Pages
{
    public partial class Index
    {
        private decimal _float = 0.01m;
        private int _pattern = 661;

        [CascadingParameter]
        public CSGencodesSettings Settings { get; set; } = default!;
        public Weapon? SelectedWeapon { get; set; }

        public List<AppliedSticker> SelectedStickers { get; set; } = [];

        public decimal Float
        {
            get => _float;
            set
            {
                _float = value;

                if (Settings.MinMaxFloats)
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

            if (Settings.MinMaxFloats)
            {
                if (Float <= weapon.min_wear)
                {
                    _float = weapon.min_wear;
                }
                else if (Float > weapon.max_wear)
                {
                    _float = weapon.max_wear;
                }
            }
        }

        private void OnStickerClicked(Sticker sticker)
        {
            if (SelectedStickers.Count < 5)
            {
                for (int posId = 0; posId < 5; posId++)
                {
                    var searchSticker = SelectedStickers.FirstOrDefault(x => x.PosId == posId);

                    if (searchSticker is null)
                    {
                        SelectedStickers.Add(new AppliedSticker(sticker, posId));
                        SortSelectedStickers();
                        break;
                    }
                }
            }
        }

  

        

        

        private void RemoveLastSticker()
        {
            SelectedStickers.RemoveAt(SelectedStickers.Count - 1);
        }


        private void SortSelectedStickers()
        {
            SelectedStickers.Sort((x, y) => x.PosId.CompareTo(y.PosId));
        }



        private async Task OnStickerWearingChange(ChangeEventArgs e, AppliedSticker sticker)
        {
            decimal.TryParse(e.Value.ToString(), CultureInfo.InvariantCulture, out decimal newValue);
            
            sticker.Scratched = newValue;
        }

    }
}