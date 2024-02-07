﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGencodes.Core.Models
{
    public class Sticker : IGenable, IBuffDetails
    {
        public string name { get; set; } = string.Empty;
        public int gen_id { get; set; }
        public string tournament { get; set; } = string.Empty;
        public string rarity { get; set; } = string.Empty;
        public int? BuffGoodsId { get; set; } = null;
        public int? BuffStickerId { get; set; } = null;
        public string? Image { get; set; } 
    }

    public class AppliedSticker : Sticker
    {
        public decimal Scratched { get; set; }
        public decimal Rotation { get; set; }
        public int PosId { get; set; }

        public AppliedSticker(Sticker sticker, int posId)
        {
            name = sticker.name;
            gen_id = sticker.gen_id;
            tournament = sticker.tournament;
            rarity = sticker.rarity;
            BuffGoodsId = sticker.BuffGoodsId;
            BuffStickerId = sticker.BuffStickerId;
            Image = sticker.Image;
            PosId = posId;
        }
    }
}
