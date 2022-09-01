namespace ToSic.Oqt.Cre8ive.Client.Settings;

public abstract class ThemePackageSettingsBase
{
    // todo: naming
    public virtual ThemeCssSettings Css { get; } = new();

    public abstract LayoutSettings Defaults { get; }

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