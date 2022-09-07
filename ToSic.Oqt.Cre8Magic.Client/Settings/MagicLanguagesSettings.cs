namespace ToSic.Oqt.Cre8Magic.Client.Settings;

public class MagicLanguagesSettings
{
    /// <summary>
    /// Dummy constructor so better find cases where it's created
    /// Note it must be without parameters for json deserialization
    /// </summary>
    public MagicLanguagesSettings() {}

    /// <summary>
    /// If true, will only show the languages which are explicitly configured.
    /// If false, will first show the configured languages, then the rest. 
    /// </summary>
    public bool HideOthers { get; set; } = false;

    /// <summary>
    /// List of languages
    /// </summary>
    public Dictionary<string, MagicLanguage>? List
    {
        get => _list;
        set => _list = InitList(value);
    }
    private Dictionary<string, MagicLanguage>? _list;

    private Dictionary<string, MagicLanguage>? InitList(Dictionary<string, MagicLanguage>? dic)
    {
        if (dic == null) return null;
        // Ensure each config knows what culture it's for, as 
        foreach (var set in dic)
            set.Value.Culture ??= set.Key;
        return dic.ToInvariant();
    }

    public static MagicLanguagesSettings Defaults = new()
    {
        HideOthers = false,
        List = new()
        {
            { "en", new() { Culture = "en", Description = "English" } }
        },
    };

}