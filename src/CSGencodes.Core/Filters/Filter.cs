namespace CSGencodes.Core.Filters;

public abstract class Filter
{
    private string _searchterm = string.Empty;

    public string Searchterm
    {
        get => _searchterm;
        set => _searchterm = value?.ToUpper() ?? string.Empty;
    }
}
