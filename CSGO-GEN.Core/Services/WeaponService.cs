using CSGO_GEN.Core.Filters;
using CSGO_GEN.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSGO_GEN.Core.Services
{
    public class WeaponService
    {
        public static List<Weapon> _weapons = new();








        public IEnumerable<Weapon> SearchWeapon(WeaponFilter filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.Searchterm))
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
