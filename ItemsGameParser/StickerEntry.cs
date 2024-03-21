using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemsGameParser
{
    public class StickerEntry
    {
        public string name { get; set; } = string.Empty;
        public string item_name { get; set; } = string.Empty;
        public string description_string { get; set; } = string.Empty;
        public string sticker_material { get; set; } = string.Empty;
        public string item_rarity { get; set; } = string.Empty;
        public string tournament_event_id { get; set; } = string.Empty;
        public string tournament_team_id { get; set; } = string.Empty;
        public string tournament_player_id { get; set; } = string.Empty;
    }
}
