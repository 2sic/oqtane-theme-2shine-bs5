using ToSic.Oqt.Themes.ToShineBs5.Client.Layouts;
using static ToSic.Oqt.Cre8ive.Client.Placeholders;

namespace ToSic.Oqt.Themes.ToShineBs5.Client;

/// <summary>
/// Should contain default values for all the scenarios where configurations are missing or not necessary
/// </summary>
public class Defaults: ThemeDefaults
{
    /// <summary>
    /// Constructor to set various defaults which the system will use.
    /// Note that this class is a singleton, so it will be re-used by everything.
    /// </summary>
    public Defaults()
    {
        SettingsJsonFile = "theme-settings.json";

        ThemePackageName = new ThemeInfo().Theme.PackageName;
    }

    /// <summary>
    /// The default Theme CSS Settings.
    /// </summary>
    public override ThemeCssSettings ThemeCss => new()
    {
        // Here you could override various defaults if you choose to change your CSS like this
        // PagePrefix = "page-";
    };

    /// <summary>
    /// Theme Settings Defaults
    /// </summary>
    public override Cre8ive.Client.Settings.ThemeSettings ThemeSettings => new()
    {
        Source = "Preset",
        Layout = new()
        {
            Logo = "logo.svg",
            LanguageMenuShow = true,
            LanguageMenuShowMin = 2,
        },
        Languages = new()
        {
            HideOthers = false,
            List = new()
            {
                { "en", new SettingsLanguage("en", "En") }
            }
        },
        Menus = new()
        {
            {
                Constants.MenuDefault, new()
                {
                    Start = "*",
                    Depth = 0,
                }
            },
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
            {
                // The Default design, if not overridden by the JSON
                Constants.DesignDefault, MenuDesignFallback
            },
            {
                // The Design configuration for Mobile menus, if not overridden by the JSON
                MenuMobile, new()
                {
                    Parts = new()
                    {
                        {
                            "ul", new()
                            {
                                ByLevel = new()
                                {
                                    { 0, "navbar-nav" },
                                    // todo: doc why collapse-PageId
                                    { PlaceHolderLevelOther, $"collapse to-shine-submenu-{MenuId}-{PageId}" },
                                },
                                InBreadcrumb = "show",
                            }
                        },
                        {
                            "li", new()
                            {
                                Classes = $"nav-item nav-{PageId} position-relative",
                                HasChildren = "has-child",
                                // todo: make sure that all the LIs or ULs in the breadcrumb don't have collapse ... or with "show"
                                Active = "active",
                                Disabled = "disabled",
                            }
                        },
                        {
                            "a", new()
                            {
                                Classes = "nav-link mobile-navigation-link",
                                Active = "active",
                            }
                        },
                        {
                            "span", new()
                            {
                                Classes = "nav-item-sub-opener",
                                InBreadcrumbFalse = "collapsed",
                            }
                        },
                    },
                }
            }
        }
    };

    /// <summary>
    /// The default/fallback design configuration for menus.
    /// Normally this would be set in the json file or the theme settings, so this wouldn't be used. 
    /// </summary>
    private static MenuDesign MenuDesignFallback = new()
    {
        Parts = new()
        {
            {
                "a", new()
                {
                    Active = "active",
                    HasChildren = "dropdown-toggle",
                    ByLevel = new()
                    {
                        { PlaceHolderLevelOther, "dropdown-item" },
                        { 1, "nav-link" },

                    }
                }
            },
            {
                "li", new()
                {
                    Classes = $"nav-item nav-{PageId}",
                    HasChildren = "has-child dropdown",
                    Active = "active",
                    Disabled = "disabled",
                }

            },
            {
                "ul", new()
                {
                    ByLevel = new()
                    {
                        { PlaceHolderLevelOther, "dropdown-menu" },
                        { 0, "navbar-nav" },
                    },
                }
            }
        },
    };


    public const string MenuMain = "Main";
    public const string MenuMobile = "Mobile";
    public const string MenuSidebar = "Sidebar";
    public const string MenuFooter = "Footer";


    #region Technical paths

    internal static string ThemePathStatic => "Themes/" + ThemePackageNameStatic;

    //public static string AssetsPath => ThemePath + "/Assets";

    internal static string ThemePackageNameStatic => _rootNamespace ??= new ThemeInfo().Theme.PackageName;
    private static string _rootNamespace;

    #endregion


}