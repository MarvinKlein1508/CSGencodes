using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_GEN.Core.Filters
{
    public abstract class Filter
    {
        private string _searchterm = string.Empty;

        public string Searchterm 
        { 
            get => _searchterm; 
            set => _searchterm = value?.ToUpper() ?? string.Empty; 
        }
    }
}
