using CSGencodes.Core.Filters;
using CSGencodes.Core.Models;

namespace CSGencodes.Core.Services;

public class StickerService
{
    public static readonly List<Sticker> _stickers = new();

    public IEnumerable<Sticker> SearchSticker(StickerFilter filter)
    {
        if (!string.IsNullOrWhiteSpace(filter.Searchterm))
        {
            if (filter.Searchterm == "*")
            {
                foreach (var sticker in _stickers.OrderBy(x => x.StickerId))
                {
                    yield return sticker;
                }
            }
            else
            {
                var searchphrases = filter.Searchterm.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var sticker in _stickers.OrderBy(x => x.StickerId))
                {
                    bool found_by_search = true;
                    foreach (var searchphrase in searchphrases)
                    {
                        if (!sticker.Name.Contains(searchphrase, StringComparison.OrdinalIgnoreCase))
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
