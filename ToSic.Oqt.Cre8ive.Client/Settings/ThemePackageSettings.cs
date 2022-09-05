namespace ToSic.Oqt.Cre8ive.Client.Settings;

/// <summary>
/// Settings for a Theme Package.
///
/// Contains semi-constants like location of assets and configuration for various parts like CSS.
/// </summary>
public partial class ThemePackageSettings
{
    // todo: naming
    public virtual PageStyling Page { get; set; } = new();

    public virtual LayoutsSettings Defaults { get; set; } = new();

    public string WwwRoot { get; set; } = "wwwroot";

    public string SettingsJsonFile { get; set; } = "theme-settings.json";

    public string ThemePackageName { get; set; } = "todo: set theme package name in your constructor";

    public string PathAssets
    {
        get => _assetsPath ??= PathTheme + "/Assets";
        set => _assetsPath = value;
    }

    public string PathTheme
    {
        get => _themePath ??= "Themes/" + ThemePackageName;
        set => _themePath = value;
    }
    private string? _assetsPath;
    private string? _themePath;
}