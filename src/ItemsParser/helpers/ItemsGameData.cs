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
