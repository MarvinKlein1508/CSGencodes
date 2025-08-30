using System.Text.RegularExpressions;

namespace ItemsParser;
/// <summary>
/// Static class for handling translations of item names in CS2
/// </summary>
public static class Translation
{
    private static readonly Regex _keyValueLine =
        new Regex("^\\s*\"(?<key>[^\"]+)\"\\s*\"(?<val>[^\"]*)\"\\s*$",
                  RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private static readonly Lazy<Dictionary<string, string>> _dict =
       new Lazy<Dictionary<string, string>>(() => LoadFile("data/csgo_english.txt"));

    public static string GetTranslation(string name)
    {
        name = name.Replace("#", string.Empty);

        return _dict.Value.TryGetValue(name.Trim().ToLower(), out var val) ? val : string.Empty;
    }


    private static Dictionary<string, string> LoadFile(string path)
    {
        var dict = new Dictionary<string, string>(StringComparer.Ordinal);
        foreach (var rawLine in File.ReadLines(path))
        {
            var line = rawLine.Trim();

            if (line.Length == 0 || line.StartsWith("//") || line is "{" or "}") continue;

            var m = _keyValueLine.Match(line);
            if (m.Success)
            {
                var key = m.Groups["key"].Value.ToLower();
                var val = m.Groups["val"].Value;
                dict[key] = val;
            }
        }
        return dict;
    }
}
