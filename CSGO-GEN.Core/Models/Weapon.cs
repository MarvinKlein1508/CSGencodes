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

        public bool IsKnife => weapon_id switch
        {
            41 or 42 or 59 or 500 or 503 or 505 or 506 or 507 or 508 or 509 or 512 or 514 or 515 or 516 or 517 or 518 or 519 or 520 or 521 or 522 or 523 or 525 => true,
            _ => false
        };
        public int StickerSlotsAmount => weapon_id switch
        {
            11 or 64 => 5,
            41 or 42 or 59 or 500 or 503 or 505 or 506 or 507 or 508 or 509 or 512 or 514 or 515 or 516 or 517 or 518 or 519 or 520 or 521 or 522 or 523 or 525 => 0,
            _ => 4
        };

        public int RarityId => rarity switch
        {
            "Consumer" => 1,
            "Industrial" => 2,
            "Milspec" => 3,
            "Restricted" => 4,
            "Classified" => 5,
            "Covert" => 6,
            "Contraband" => 7,
            _ => 1,
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
