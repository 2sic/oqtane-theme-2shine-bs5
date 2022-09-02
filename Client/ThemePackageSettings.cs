using ToSic.Oqt.Themes.ToShineBs5.Client.Layouts;

namespace ToSic.Oqt.Themes.ToShineBs5.Client;

/// <summary>
/// Should contain default values for all the scenarios where configurations are missing or not necessary
/// Note that this class is a singleton, so it will be re-used by everything.
/// </summary>
public class ThemePackageSettings: ThemePackageSettingsBase
{
    /// <summary>
    /// Constructor to set various defaults which the system will use.
    /// </summary>
    public ThemePackageSettings()
    {
        // The package name is important, as it's used to find assets etc.
        ThemePackageName = new ThemeInfo().Theme.PackageName;

        // The json file in the theme folder folder containing all kinds of settings etc.
        SettingsJsonFile = "theme-settings.json";
    }


    /// <summary>
    /// The default Theme CSS Settings.
    /// </summary>
    public override ThemeCssSettings Css => new()
    {
        // Here you could override various defaults if you choose to change your CSS like this
        // PagePrefix = "page-";
    };

    /// <summary>
    /// Theme Settings Defaults, used to lookup things which the json file doesn't specify.
    /// Normally you don't want to change this, but just set everything in the json
    /// </summary>
    public override LayoutSettings Defaults => new()
    {
        Source = "Preset",
        Layout = new()
        {
            Logo = "logo.svg",
            LanguageMenuShow = true,
            LanguageMenuShowMin = 2,
        },
        Languages = LanguagesSettings.Defaults,
        Menus = new()
        {
            { Constants.MenuDefault, MenuConfig.Defaults },
            {
                MenuMain, new()
                {
                    Start = "*",
                    Depth = 1,
                }
            }
        },
        Designs = new()
        {
            // The Default design, if not overridden in the JSON
            { Constants.DesignDefault, MenuDesignSettings.Defaults },
            // The Design configuration for Mobile menus, if not overridden by the JSON
            { Constants.DesignMobile, MenuDesignSettings.MobileDefaults }
        }
    };


    public const string MenuMain = "Main";
    public const string MenuMobile = "Mobile";
    public const string MenuSidebar = "Sidebar";
    public const string MenuFooter = "Footer";


    #region Technical paths

    internal static string ThemePathStatic => _themePathStatic ??= "Themes/" + new ThemeInfo().Theme.PackageName;
    private static string _themePathStatic;

    #endregion


}