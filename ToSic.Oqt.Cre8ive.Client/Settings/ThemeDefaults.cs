namespace ToSic.Oqt.Cre8ive.Client.Settings;

public abstract class ThemeDefaults
{
    // todo: naming
    public abstract ThemeCssSettings ThemeCss { get; }

    public abstract ThemeSettings ThemeSettings { get; }

    public string WwwRoot { get; set; } = "wwwroot";

    public string SettingsJsonFile { get; set; } = "theme-settings.json";

    public string ThemePackageName { get; set; } = "todo: set theme package name in your constructor";

    public string AssetsPath
    {
        get => _assetsPath ??= ThemePath + "/Assets";
        set => _assetsPath = value;
    }

    public string ThemePath
    {
        get => _themePath ??= "Themes/" + ThemePackageName;
        set => _themePath = value;
    }
    private string? _assetsPath;
    private string? _themePath;
}