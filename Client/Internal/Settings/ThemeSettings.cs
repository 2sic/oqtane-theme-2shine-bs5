namespace ToSic.Oqt.Themes.ToShineBs5.Client.Internal.Settings;

public class ThemeSettings
{
    public float Version { get; set; }

    public string Source { get; set; }

    public SettingsLayout Layout { get; set; }

    public SettingsLanguages Languages { get; set; }

    /// <summary>
    /// The menu definitions
    /// </summary>
    public Dictionary<string, MenuConfig> Menus { get; set; } = new();

    /// <summary>
    /// Design definitions of the menu
    /// </summary>
    public Dictionary<string, MenuDesign> Designs { get; set; } = new();

    public MenuConfig GetMenu(string name) => Menus?.FindInvariant(name);
    public MenuDesign GetDesign(string name) => Designs?.FindInvariant(name);
}

public class SettingsLayout
{
    public string Logo { get; set; }
    public bool LanguageMenuShow { get; set; } = true;
    public int LanguageMenuShowMin { get; set; } = 0;
}

public class SettingsLanguages
{
    public bool HideOthers { get; set; } = false;
    public List<SettingsLanguage> List { get; set; }
}