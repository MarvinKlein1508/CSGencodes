using CSGO_GEN.Core.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;

namespace BuffIdGrabber
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string json = await File.ReadAllTextAsync("stickers.json");

            List<Sticker> stickers = JsonSerializer.Deserialize<List<Sticker>>(json)!;



            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Cookie", "");
            //https://buff.163.com/api/market/goods?game=csgo

            //https://buff.163.com/api/market/goods?game=csgo&page_size=80&page_num=1

            List<BuffDetails> items = new();

            for (int i = 0; i < Int32.MaxValue; i++)
            {
                string url = $"https://buff.163.com/api/market/goods?game=csgo&page_size=80&page_num={i + 1}";
                BuffObject? buff_object = await client.GetFromJsonAsync<BuffObject>(url);
                await Task.Delay(3000);

                if (buff_object is not null)
                {
                    // Check if we have a sticker
                    Regex regex = new Regex("(?<=\\\"sticker_v2\", \\\"id\\\": )\\d+");
                    foreach (BuffItem item in buff_object.data.items)
                    {
                        if (item.market_hash_name.Contains("Sticker", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"Name: {item.market_hash_name}; ID: {item.id}");

                            await Task.Delay(2000);
                            url = $"https://buff.163.com/goods/{item.id}";
                            string page_html = await client.GetStringAsync(url);

                            var result = regex.Match(page_html);

                            if (result.Success && int.TryParse(result.Value, out int searchId))
                            {
                                BuffDetails details = new BuffDetails(item.id, item.market_hash_name, searchId);

                                if (!items.Contains(details))
                                {
                                    items.Add(details);
                                }
                            }


                        }
                    }
                }

                if (buff_object.data.total_page == i)
                {
                    break;
                }
            }

            var items_sorted = items.OrderBy(x => x.Id).ToArray();

            string items_json = JsonSerializer.Serialize(items_sorted, new JsonSerializerOptions
            {
                WriteIndented = true,
            });


            await File.WriteAllTextAsync("buff_stickers.json", items_json);






        }
    }


    

    public class BuffObject
    {
        public string code { get; set; }
        public BuffData data { get; set; }
        public object msg { get; set; }
    }

    public class BuffData
    {
        public BuffItem[] items { get; set; }
        public int page_num { get; set; }
        public int page_size { get; set; }
        public int total_count { get; set; }
        public int total_page { get; set; }
    }

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

    public class BuffGoods_Info
    {
        public string icon_url { get; set; }
        public BuffInfo info { get; set; }
        public object item_id { get; set; }
        public string original_icon_url { get; set; }
        public string steam_price { get; set; }
        public string steam_price_cny { get; set; }
    }

    public class BuffInfo
    {
        public BuffTags tags { get; set; }
    }

    public class BuffTags
    {
        public BuffExterior exterior { get; set; }
        public BuffQuality quality { get; set; }
        public BuffRarity rarity { get; set; }
        public BuffType type { get; set; }
        public BuffWeapon weapon { get; set; }
    }

    public class BuffExterior
    {
        public string category { get; set; }
        public int id { get; set; }
        public string internal_name { get; set; }
        public string localized_name { get; set; }
    }

    public class BuffQuality
    {
        public string category { get; set; }
        public int id { get; set; }
        public string internal_name { get; set; }
        public string localized_name { get; set; }
    }

    public class BuffRarity
    {
        public string category { get; set; }
        public int id { get; set; }
        public string internal_name { get; set; }
        public string localized_name { get; set; }
    }

    public class BuffType
    {
        public string category { get; set; }
        public int id { get; set; }
        public string internal_name { get; set; }
        public string localized_name { get; set; }
    }

    public class BuffWeapon
    {
        public string category { get; set; }
        public int id { get; set; }
        public string internal_name { get; set; }
        public string localized_name { get; set; }
    }

}