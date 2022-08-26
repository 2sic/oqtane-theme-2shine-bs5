using ToSic.Oqt.Themes.ToShineBs5.Client.Models;

namespace ToSic.Oqt.Themes.ToShineBs5.Client;

/// <summary>
/// Constants and helpers related to creating Css and Css Classes.
///
/// If you change these, you must also update the SCSS files. 
/// </summary>
internal class ThemeCss
{
    /// <summary>
    /// Prefix for all css classes which contain information about the page.
    /// </summary>
    public const string PagePrefix = "page-";

    public const string PageIsHome = $"{PagePrefix}is-home";

    public const string PageRootPrefix = $"{PagePrefix}root-";

    public const string PageParentPrefix = $"{PagePrefix}parent-";

    /// <summary>
    /// Prefix for all CSS classes with information about the site
    /// </summary>
    public const string SitePrefix = "site-";

    public const string NavLevelPrefix = "nav-level-";

    public const string LayoutPrefix = "to-shine-";
    public const string LayoutVariationPrefix = $"{LayoutPrefix}variation-";
    public const string LayoutAdminContainer = $"{LayoutPrefix}admin-container";

    public const string PanePrefix = "pane-";
    public const string PaneIsEmpty = $"{PanePrefix}is-empty";

    public const string ModulePrefix = "module-";
    public const string ModuleUnpublished = $"{ModulePrefix}unpublished";

    public static MenuCssConfig MenuCssDefaults = new()
    {
        LiClasses = "nav-item",
        AActive = "active",
        AInactive = "",
        LiActive = "active",
        LiInactive = "inactive",
    };

    public static MenuCssConfig MobileCssConfig = new()
    {
        ListClasses = "",
        LiClasses = "position-relative",
        AClasses = "nav-link mobile-navigation-link",
    };

    public static MenuCssConfig SidebarCssConfig = new()
    {
        ListClasses = "",
        LiClasses = "position-relative",
        AClasses = "nav-link",
    };
}