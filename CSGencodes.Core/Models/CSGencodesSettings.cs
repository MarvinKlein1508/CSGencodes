using CSGencodes.Core.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGencodes.Core.Models
{
    public class CSGencodesSettings
    {
        public bool MinMaxFloats { get; set; } = false;
        public StickerFilter StickerFilter { get; set; } = new();
        public WeaponFilter WeaponFilter { get; set; } = new();
    }
}
