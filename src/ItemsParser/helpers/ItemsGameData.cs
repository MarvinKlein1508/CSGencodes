using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemsParser.helpers;
internal static class ItemsGameData
{
    internal static string ItemsGame { get; }
    static ItemsGameData()
    {
        string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "items_game.txt");
        ItemsGame = File.ReadAllText(filename);
    }
}
