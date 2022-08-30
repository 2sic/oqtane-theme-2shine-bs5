using ToSic.Oqt.Themes.ToShineBs5.Client.Layouts;
using static ToSic.Oqt.Themes.ToShineBs5.Client.ThemeCss;

namespace ToSic.Oqt.Themes.ToShineBs5.Client;

/// <summary>
/// Should contain default values for all the scenarios where configurations are missing or not necessary
/// </summary>
public class Defaults
{
    /// <summary>
    /// The default/fallback design configuration for menus.
    /// Normally this would be set in the json file or the theme settings, so this wouldn't be used. 
    /// </summary>
    public static MenuDesign MenuDesignFallback = new()
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
                    Classes = $"nav-item nav-{PlaceHolderPageId}",
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


    public static Internal.Settings.ThemeSettings DefaultThemeSettings = new()
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
                MenuDefault, new()
                {
                    Start = "*",
                    Depth = 0,
                }
            },
            {
                MenuMain, new ()
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
                MenuDesignDefault, MenuDesignFallback
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
                                    { PlaceHolderLevelOther, $"collapse to-shine-submenu-{PlaceholderMenuId}-{PlaceHolderPageId}" },
                                },
                                InBreadcrumb = "show",
                            }
                        },
                        {
                            "li", new()
                            {
                                Classes = $"nav-item nav-{PlaceHolderPageId} position-relative",
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
    

    public const string PlaceholderAssetsPath = "[ASSETS-PATH]";
    public const string PlaceholderMenuId = "[MENUID]";

    #region Technical paths

    public const string WwwRoot = "wwwroot";

    public static string ThemePath => "Themes/" + ThemePackageName;

    public static string AssetsPath => ThemePath + "/Assets";

    public static string ThemePackageName => _rootNamespace ??= new ThemeInfo().Theme.PackageName;
    private static string _rootNamespace;

    #endregion

    #region Navigation Constants

    public const string NavigationJsonFile = "theme-settings.json";

    #endregion

}