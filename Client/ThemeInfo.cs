using Oqtane.Models;
using Oqtane.Themes;
using static ToSic.Oqt.Cre8Magic.Client.MagicPlaceholders;

// Important: This must match the namespace of the layouts
// otherwise the Oqtane registration won't work as expected. 
namespace ToSic.Oqt.Themes.ToShineBs5.Client;

/// <summary>
/// This class / file serves a few purposes:
/// 
/// 1. The theme-info for registration in Oqtane - because it inherits <see cref="ITheme"/>
/// 2. Contains names / constants like `MenuMobile` used in the theme
/// 2. Contains the default configurations/settings in the static `PackageDefaults`
/// </summary>
public class ThemeInfo : ITheme
{
    /// <summary>
    /// The standard information object for Oqtane to register the theme.
    /// </summary>
    public Theme Theme => new()
    {
        Name = "ToShine Bootstrap 5",
        Version = "2.0.0",
        // Settings still very WIP
        //ThemeSettingsType = typeof(ThemeSettingsUi.Settings).AssemblyQualifiedName,
        //ContainerSettingsType = "Oqtane.Theme.ToSic.ContainerSettings, Oqtane.Theme.ToSic.Oqtane",
        PackageName = "ToSic.Oqt.Themes.ToShineBs5",
    };

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

    #region Package Theme Defaults / Settings etc.

    /// <summary>
    /// Default settings used in this package.
    /// They are defined here and given as initial values to the ThemeSettingsService in the Default Razor file.
    /// 
    /// You don't need to do much here, because all settings should then come from the json file. 
    /// </summary>
    public static MagicPackageSettings ThemePackageDefaults = new()
    {
        // The package name is important, as it's used to find assets etc.
        PackageName = new ThemeInfo().Theme.PackageName,

        // The json file in the theme folder folder containing all kinds of settings etc.
        SettingsJsonFile = "theme-settings.json",

        // Theme Settings Defaults, used to lookup things which the json file doesn't specify.
        // Normally you don't want to change this, but just set everything in the json
        //Defaults = new()
        //{
            //    // The source is just a name, which you may sometimes see in debug messages to see where the setting came from
            //    Source = "Preset",

            //PageDesigns = new()
            //{
            //    { MagicConstants.Default, MagicPageDesign.Defaults}
            //}
            //    // Layout settings
            //    Layouts = new()
            //    {
            //        {
            //            MagicConstants.Default, new()
            //            {
            //                Logo = "logo.svg",
            //                LanguageMenuShow = true,
            //                LanguageMenuShowMin = 2,
            //                //Breadcrumbs = "Test",
            //            }
            //        }
            //    },
            //    Languages = new()
            //    {
            //        { MagicConstants.Default, MagicLanguagesSettings.Defaults }
            //    },
            //    Breadcrumbs = new()
            //    {
            //        { MagicConstants.Default, MagicBreadcrumbSettings.Defaults },
            //    },
            //    Menus = new()
            //    {
            //        { MagicConstants.Default, MagicMenuSettings.Defaults },
            //    },
            //    MenuDesigns = new()
            //    {
            //        { MagicConstants.Default, MagicMenuDesignSettings.Defaults },
            //    }
        //}
    };

    #endregion
}
