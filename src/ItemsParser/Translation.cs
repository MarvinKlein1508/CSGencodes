using System.Text.RegularExpressions;

namespace ItemsParser;
public static class Translation
{
    private static string _translations;
    static Translation()
    {
        string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "csgo_english.txt");
        _translations = File.ReadAllText(filename);
    }

    public static string GetTranslation(string name)
    {
        string nameSanitized = name.Replace("#", string.Empty);
        string pattern = $"(?<={nameSanitized}...).*\"";
        Regex nameRegex = new Regex(pattern);
        var match = nameRegex.Match(_translations);
        if (match.Success && match.Groups.Count > 0)
        {
            return match.Groups[0].Value.Replace("\"", string.Empty).Trim();
        }

        return string.Empty;
    }
}
