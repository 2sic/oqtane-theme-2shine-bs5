using ToSic.Oqt.Themes.ToShineBs5.Client.Layouts;

namespace ToSic.Oqt.Themes.ToShineBs5.Client;

/// <summary>
/// Should contain default values for all the scenarios where configurations are missing or not necessary
/// Note that this class is a singleton, so it will be re-used by everything.
/// </summary>
public static class ToShinePackageSettings
{
    #region Menu Names for this Theme, used in various Razor files

    public const string MenuMain = "Main";
    public const string MenuMobile = "Mobile";
    public const string MenuSidebar = "Sidebar";
    public const string MenuFooter = "Footer";

    #endregion

    #region Paths used in the Theme for getting JS and CSS files

    internal static string ThemePath => _themePath ??= "Themes/" + new ThemeInfo().Theme.PackageName;
    private static string _themePath;

    #endregion

    /// <summary>
    /// Default settings used in this package.
    /// They are defined here and given as initial values to the ThemeSettingsService in the Default Razor file.
    /// 
    /// You don't need to do much here, because all settings should then come from the json file. 
    /// </summary>
    public static ThemePackageSettings PackageDefaults = new() 
    {
        // The package name is important, as it's used to find assets etc.
        ThemePackageName = new ThemeInfo().Theme.PackageName,

        // The json file in the theme folder folder containing all kinds of settings etc.
        SettingsJsonFile = "theme-settings.json",

        // The Theme CSS Settings
        // It contains names/prefixes of CSS classes which are added to the HTML by code. 
        // You only ever need to change this if you modify the generated CSS to use other prefixes etc.
        Css = new()
        {
            // Here you could override various defaults if you choose to change your CSS like this
            // PagePrefix = "page-";
        },

        // Theme Settings Defaults, used to lookup things which the json file doesn't specify.
        // Normally you don't want to change this, but just set everything in the json
        Defaults = new()
        {
            // The source is just a name, which you may sometimes see in debug messages to see where the setting came from
            Source = "Preset",

            // Layout settings
            Layout = new()
            {
                Logo = "logo.svg",
                LanguageMenuShow = true,
                LanguageMenuShowMin = 2,
                //Breadcrumbs = "Test",
            },
            Languages = LanguagesSettings.Defaults,
            Breadcrumbs = new()
            {
                { Constants.Default, BreadcrumbSettings.Defaults },
                //{ "Test", new()
                //{
                //    Separator = " to ",
                //}}
            },
            Menus = new()
            {
                { Constants.Default, MenuConfig.Defaults },
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
                { Constants.Default, MenuDesignSettings.Defaults },
                // The Design configuration for Mobile menus, if not overridden by the JSON
                { Constants.DesignMobile, MenuDesignSettings.MobileDefaults }
            }
        }
    };

}