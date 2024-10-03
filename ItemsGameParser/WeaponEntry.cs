using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemsGameParser
{
    public class WeaponEntry
    {
        public string name { get; set; } = string.Empty;
        public string description_string { get; set; } = string.Empty;
        public string description_tag { get; set; } = string.Empty;
        public string style { get; set; } = string.Empty;
        public string wear_remap_min { get; set; } = string.Empty;
        public string wear_remap_max { get; set; } = string.Empty;
        public string composite_material_path { get; set; } = string.Empty;
    }
}
