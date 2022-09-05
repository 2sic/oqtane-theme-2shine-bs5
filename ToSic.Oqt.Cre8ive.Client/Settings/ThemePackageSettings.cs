namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class ThemePackageSettings
{
    // todo: naming
    public virtual ThemeCssSettings Css { get; set; } = new();

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

    internal class ThemePackageSettingsFallback: ThemePackageSettings
    {
        public override LayoutsSettings Defaults => new()
        {
            Source = "Preset",
            Layout = LayoutSettings.Defaults,
            Languages = LanguagesSettings.Defaults,
            Breadcrumbs = new()
            {
                { Constants.Default, BreadcrumbSettings.Defaults }
            },
            Menus = new()
            {
                { Constants.Default, MenuConfig.Defaults },
            },
            Designs = new()
            {
                // The Default design, if not overridden in the JSON
                { Constants.Default, MenuDesignSettings.Defaults },
                // The Design configuration for Mobile menus, if not overridden by the JSON
                { Constants.DesignMobile, MenuDesignSettings.MobileDefaults }
            }
        };
    }

    internal static ThemePackageSettingsFallback Fallback = new();
}