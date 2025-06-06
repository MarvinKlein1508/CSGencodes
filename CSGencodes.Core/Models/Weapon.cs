﻿using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;

namespace CSGencodes.Core.Models
{
    public class Weapon : IGenable
    {
        public string name { get; set; } = string.Empty;
        public decimal min_wear { get; set; }
        public decimal max_wear { get; set; }
        public bool trade_up { get; set; }
        public int weapon_id { get; set; }
        public int gen_id { get; set; }
        public string collection { get; set; } = string.Empty;
        public string rarity { get; set; } = string.Empty;
        public string? Image { get; set; }

        [JsonIgnore]
        public bool IsKnife => weapon_id switch
        {
            41 or 42 or 59 or 500 or 503 or 505 or 506 or 507 or 508 or 509 or 512 or 514 or 515 or 516 or 517 or 518 or 519 or 520 or 521 or 522 or 523 or 525 => true,
            _ => false
        };
        [JsonIgnore]
        public int StickerSlotsAmount => weapon_id switch
        {
            41 or 42 or 59 or 500 or 503 or 505 or 506 or 507 or 508 or 509 or 512 or 514 or 515 or 516 or 517 or 518 or 519 or 520 or 521 or 522 or 523 or 525 => 0,
            _ => 5
        };
        [JsonIgnore]
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
        public string GetGencode(decimal @float, int pattern, string customName, List<AppliedSticker> stickers)
        {
            StringBuilder sb = new();
            sb.Append($"!gen {weapon_id} {gen_id} {pattern} {@float.ToString("0.00000000000000", CultureInfo.InvariantCulture)}");



            var sortedStickers = stickers.OrderBy(x => x.PosId).ToList();

            // We have two stickers, both same position

            int addedStickers = 0;
            int currentPos = 0;
            foreach (var sticker in sortedStickers)
            {

                while (sticker.PosId != currentPos)
                {
                    sb.Append(" 0 0.00");
                    currentPos++;
                }

                sb.Append($" {sticker.gen_id} {sticker.Scratched.ToString("0.00", CultureInfo.InvariantCulture)}");
                currentPos++;
                addedStickers++;
            }

            if (!string.IsNullOrWhiteSpace(customName))
            {
                if (addedStickers != 5)
                {
                    for (int i = addedStickers; i < 5; i++)
                    {
                        sb.Append(" 0 0.00");
                        currentPos++;
                        addedStickers++;
                    }

                    sb.Append(" 0");
                    sb.Append(" 0");
                    sb.Append($" {customName}");
                }
            }

            string gencode = sb.ToString();
            return gencode;
        }

    }
}
