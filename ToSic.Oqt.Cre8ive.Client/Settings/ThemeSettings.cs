namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class ThemeSettings
{
    ///// <summary>
    ///// Version number when loading from JSON to verify it's what we expect
    ///// </summary>
    //public float Version { get; set; }

    /// <summary>
    /// Source of these settings / where they came from, to ensure that we can see in debug where a value was picked up from
    /// </summary>
    public string Source { get; set; } = "Unknown";

    public SettingsLayout? Layout { get; set; }

    public SettingsLanguages? Languages { get; set; }

    /// <summary>
    /// The menu definitions
    /// </summary>
    public Dictionary<string, MenuConfig> Menus { get; set; } = new();

    /// <summary>
    /// Design definitions of the menu
    /// </summary>
    public Dictionary<string, MenuDesign> Designs { get; set; } = new();

    public MenuConfig? GetMenu(string name) => Menus?.FindInvariant(name);
    public MenuDesign? GetDesign(string name) => Designs?.FindInvariant(name);
}

public class SettingsLayout
{
    public string? Logo { get; set; }
    public bool LanguageMenuShow { get; set; } = true;
    public int LanguageMenuShowMin { get; set; } = 0;
}

public class SettingsLanguages
{
    /// <summary>
    /// If true, will only show the languages which are explicitly configured.
    /// If false, will first show the configured languages, then the rest. 
    /// </summary>
    public bool HideOthers { get; set; } = false;

    /// <summary>
    /// List of languages
    /// </summary>
    public Dictionary<string, SettingsLanguage> List
    {
        get => _list;
        set => _list = InitList(value);
    }
    private Dictionary<string, SettingsLanguage> _list;

    private Dictionary<string, SettingsLanguage> InitList(Dictionary<string, SettingsLanguage> dic)
    {
        // Ensure each config knows what culture it's for, as 
        foreach (var set in dic) 
            set.Value.Culture ??= set.Key;
        return new Dictionary<string, SettingsLanguage>(dic, StringComparer.InvariantCultureIgnoreCase);
    }
}