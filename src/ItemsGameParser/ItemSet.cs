namespace ItemsGameParser;
public class ItemSet
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCollection { get; set; }
    public Dictionary<string, string> Items { get; set; } = [];
}
