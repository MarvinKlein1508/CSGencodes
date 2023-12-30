using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGencodes.Core.Filters
{
    public class WeaponFilter : Filter
    {
        public bool IncludeKnives { get; set; } = true;
    }
}
