using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_GEN.Core.Models
{
    public class Weapon : IGenable
    {
        public string name { get; set; }
        public decimal min_wear { get; set; }
        public decimal max_wear { get; set; }
        public bool trade_up { get; set; }
        public int weapon_id { get; set; }
        public int gen_id { get; set; }
        public string collection { get; set; } = string.Empty;
        public string rarity { get; set; } = string.Empty;

        public int StickerSlotsAmount => weapon_id switch
        {
            11 or 64 => 5,
            _ => 4
        };

        public string GetGencode(decimal @float, int pattern, List<AppliedSticker> stickers)
        {
            StringBuilder sb = new();
            sb.Append($"!gen {weapon_id} {gen_id} {pattern} {@float.ToString("0.00000000000000", CultureInfo.InvariantCulture)}");

            int max_size = stickers.Count > StickerSlotsAmount ? StickerSlotsAmount : stickers.Count;

            for (int i = 0; i < max_size; i++)
            {
                var sticker = stickers[i];
                sb.Append($" {sticker.gen_id} {sticker.Scratched.ToString("0.00", CultureInfo.InvariantCulture)}");
            }


            string gencode = sb.ToString();
            return gencode;
        }
    }

}
