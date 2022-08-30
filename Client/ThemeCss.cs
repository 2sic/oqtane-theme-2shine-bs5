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

    public const string PlaceHolderPageId = "[PAGEID]";
    public const int PlaceHolderLevelOther = -1;

    public const string MenuMain = "Main";
    public const string MenuDefault = "Default";
    public const string MenuMobile = "Mobile";
    public const string MenuSidebar = "Sidebar";
    public const string MenuFooter = "Footer";
    public const string MenuDesignDefault = "Default";

    // TODO: Review if we should have a menu-id, as otherwise multiple menus open/collapse together


}