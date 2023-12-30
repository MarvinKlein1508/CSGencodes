using CSGencodes.Core.Filters;
using CSGencodes.Core.Models;


namespace CSGencodes.Core.Services
{
    public class WeaponService
    {
        public static List<Weapon> _weapons = new();
        public IEnumerable<Weapon> SearchWeapon(WeaponFilter filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.Searchterm))
            {
                if (filter.Searchterm == "*")
                {
                    foreach (var weapon in _weapons.OrderBy(x => x.gen_id))
                    {
                        yield return weapon;
                    }
                }
                else
                {
                    var searchphrases = filter.Searchterm.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    foreach (var weapon in _weapons)
                    {
                        if (!filter.IncludeKnives && weapon.IsKnife)
                        {
                            continue;
                        }

                        bool found_by_search = true;
                        foreach (var searchphrase in searchphrases)
                        {
                            if (!weapon.name.Contains(searchphrase, StringComparison.OrdinalIgnoreCase))
                            {
                                found_by_search = false;
                                break;
                            }

                        }

                        if (found_by_search)
                        {
                            yield return weapon;
                        }
                    }
                }
            }
        }
    }
}
