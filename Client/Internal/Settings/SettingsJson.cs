using System.Collections.Generic;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Internal.Settings;

public class SettingsJson
{
    public float Version { get; set; }

    public SettingsJsonLayout Layout { get; set; }

    public SettingsJsonLanguages Languages { get; set; }

    /// <summary>
    /// The menu definitions
    /// </summary>
    public Dictionary<string, MenuConfig> Menus { get; set; } = new();

    /// <summary>
    /// Design definitions of the menu
    /// </summary>
    public Dictionary<string, MenuDesign> Designs { get; set; } = new();
}

public class SettingsJsonLayout
{
    public string Logo { get; set; }
}

public class SettingsJsonLanguages
{
    public SettingsLanguage[] List { get; set; }
}