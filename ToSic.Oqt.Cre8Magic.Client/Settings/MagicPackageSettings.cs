using ToSic.Oqt.Cre8Magic.Client.Styling;

namespace ToSic.Oqt.Cre8Magic.Client.Settings;

/// <summary>
/// Settings for a Theme Package.
///
/// Contains semi-constants like location of assets and configuration for various parts like CSS.
/// </summary>
public partial class MagicPackageSettings
{
    /// <summary>
    /// All kinds of settings for the layout, how it should be etc.
    /// Should usually only serve as backup in case the JSON fails.
    /// </summary>
    public MagicSettingsCatalog? Defaults { get; set; }

    public string WwwRoot { get; set; } = "wwwroot";

    public string SettingsJsonFile { get; set; } = "theme-settings.json";

    public string PackageName { get; set; } = "todo: set theme package name in your constructor";

    public string PathAssets
    {
        get => _assetsPath ??= PathTheme + "/Assets";
        set => _assetsPath = value;
    }

    public string PathTheme
    {
        get => _themePath ??= "Themes/" + PackageName;
        set => _themePath = value;
    }
    private string? _assetsPath;
    private string? _themePath;
}