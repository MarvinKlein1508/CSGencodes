using CSGO_GEN.Core.Filters;
using CSGO_GEN.Core.Models;
using System.Text.Json;

namespace CSGO_GEN.Core.Services
{
    public class StickerService
    {
        public static List<Sticker> _stickers = new();
        
        public IEnumerable<Sticker> SearchSticker(StickerFilter filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.Searchterm))
            {
                if (filter.Searchterm == "*")
                {
                    foreach (var sticker in _stickers.OrderBy(x => x.gen_id))
                    {
                        yield return sticker;
                    }
                }
                else
                {
                    var searchphrases = filter.Searchterm.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    foreach (var sticker in _stickers.OrderBy(x => x.gen_id))
                    {
                        bool found_by_search = true;
                        foreach (var searchphrase in searchphrases)
                        {
                            if (!sticker.name.Contains(searchphrase, StringComparison.OrdinalIgnoreCase))
                            {
                                found_by_search = false;
                                break;
                            }

                        }

                        if (found_by_search)
                        {
                            yield return sticker;
                        }
                    }
                }
            }
        }
    }
}
