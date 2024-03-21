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

        /// <summary>
        /// Generates a Steam Community Market URL which searchs for all skins with the selected stickers.
        /// </summary>
        /// <returns></returns>
        private string GetSteamMarketUrl()
        {
            if (SelectedStickers.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new();
            sb.Append("https://steamcommunity.com/market/search?q=");

            string query = HttpUtility.UrlEncode($"\"{string.Join(",", SelectedStickers.Select(x => x.name))}\"");

            sb.Append(query);
            sb.Append("&descriptions=1&category_730_ItemSet%5B%5D=any&category_730_Weapon%5B%5D=any&category_730_Quality%5B%5D=#p1_price_asc");

            string url = sb.ToString();

            return url;
        }

        private string GetSkinportUrl()
        {
            if (SelectedStickers.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new();
            sb.Append("https://skinport.com/market?sticker=");

            string query = $"{string.Join("%2C", SelectedStickers.Select(x => x.name.Replace(" ", "+")))}";

            sb.Append(query);

            sb.Append("&r=erdbeerchen02");


            string url = sb.ToString();

            return url;
        }

        private string GetCsgofloatUrl()
        {
            // Example: https://csgofloat.com/db?defIndex=7&paintIndex=282&min=0.1&max=0.7&stickers=%5B%7B%22i%22:%225015%22%7D,%7B%22i%22:%225015%22%7D,%7B%22i%22:%225015%22%7D,%7B%22i%22:%225015%22%7D%5D
            StringBuilder sb = new();
            sb.Append("https://csgofloat.com/db?");

            List<string> parameters = new();

            if (SelectedWeapon is not null)
            {
                parameters.Add($"defIndex={SelectedWeapon.weapon_id}");
                parameters.Add($"paintIndex={SelectedWeapon.gen_id}");
            }

            if (SelectedStickers.Count != 0)
            {
                // Example: [{"i":"5015"},{"i":"5015"},{"i":"5015"},{"i":"5015"}]
                var stickers = SelectedStickers.Take(4);
                List<string> sticker_values = new();
                foreach (var sticker in stickers)
                {
                    sticker_values.Add($"{{\"i\":\"{sticker.gen_id}\"}}");
                }


                parameters.Add($"stickers=[{string.Join(",", sticker_values)}]");
            }


            if (parameters.Count == 0)
            {
                return string.Empty;
            }

            sb.Append(string.Join("&", parameters));

            return sb.ToString();
        }

        private void RemoveLastSticker()
        {
            SelectedStickers.RemoveAt(SelectedStickers.Count - 1);
        }


        private void SortSelectedStickers()
        {
            SelectedStickers.Sort((x, y) => x.PosId.CompareTo(y.PosId));
        }

        private string? GetBuff163Url()
        {
            // Example: https://buff.163.com/market/csgo#tab=selling&page_num=1&extra_tag_ids=16226,16226,16226,16226  
            List<int> searchIds = [];
            if (SelectedStickers.Count != 0)
            {
                foreach (var sticker in SelectedStickers)
                {
                    if (sticker.BuffStickerId is not null)
                    {
                        searchIds.Add((int)sticker.BuffStickerId);
                    }
                }
            }

            if (searchIds.Count == 0)
            {
                return null;
            }

            return $"https://buff.163.com/market/csgo#tab=selling&page_num=1&extra_tag_ids={String.Join(",", searchIds)}";
        }

        private async Task OnStickerWearingChange(ChangeEventArgs e, AppliedSticker sticker)
        {
            decimal.TryParse(e.Value.ToString(), CultureInfo.InvariantCulture, out decimal newValue);
            
            sticker.Scratched = newValue;
        }

        private async Task OnStickerRotationChange(ChangeEventArgs e, AppliedSticker sticker)
        {
        }
    }
}