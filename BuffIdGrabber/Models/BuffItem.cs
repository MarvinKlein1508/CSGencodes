namespace BuffIdGrabber.Models
{
    public class BuffItem
    {
        public int appid { get; set; }
        public bool bookmarked { get; set; }
        public string buy_max_price { get; set; }
        public int buy_num { get; set; }
        public bool can_bargain { get; set; }
        public bool can_search_by_tournament { get; set; }
        public object description { get; set; }
        public string game { get; set; }
        public BuffGoods_Info goods_info { get; set; }
        public bool has_buff_price_history { get; set; }
        public int id { get; set; }
        public string market_hash_name { get; set; }
        public string market_min_price { get; set; }
        public string name { get; set; }
        public string quick_price { get; set; }
        public string sell_min_price { get; set; }
        public int sell_num { get; set; }
        public string sell_reference_price { get; set; }
        public string short_name { get; set; }
        public string steam_market_url { get; set; }
        public int transacted_num { get; set; }
    }

}