namespace ToSic.Oqt.Cre8ive.Client.Settings;

/// <summary>
/// Constants and helpers related to creating Css and Css Classes.
///
/// If you change these, you must also update the SCSS files. 
/// </summary>
// TODO: CREATE A NORMAL CLASS WITH PROPERTIES WHICH A THEME CAN REPLACE
public class ThemeCssSettings
{
    private string? _pageIsHome;
    private string? _pageRootPrefix;
    private string? _pageParentPrefix;
    private string? _layoutVariationPrefix;
    private string? _layoutAdminContainer;
    private string? _paneIsEmpty;
    private string? _moduleUnpublished;
    private const string SitePrefixDefault = "site-";
    private const string PagePrefixDefault = "page-";
    private const string LayoutPrefixDefault = "to-shine-";
    private const string PanePrefixDefault = "pane-";
    private const string ModulePrefixDefault = "module-";
    private const string NavLevelPrefixDefault = "nav-level-";

    /// <summary>
    /// Prefix for all css classes which contain information about the page.
    /// </summary>
    public string PagePrefix { get; set; } = PagePrefixDefault;

    public string PageIsHome
    {
        get => _pageIsHome ??= $"{PagePrefix}is-home";
        set => _pageIsHome = value;
    }

    public string PageRootPrefix
    {
        get => _pageRootPrefix ??= $"{PagePrefix}root-";
        set => _pageRootPrefix = value;
    }

    public string PageParentPrefix
    {
        get => _pageParentPrefix ??= $"{PagePrefix}parent-";
        set => _pageParentPrefix = value;
    }

    /// <summary>
    /// Prefix for all CSS classes with information about the site
    /// </summary>
    public string SitePrefix { get; set; } = SitePrefixDefault;

    public string NavLevelPrefix { get; set; } = NavLevelPrefixDefault;

    public string LayoutPrefix { get; set; } = LayoutPrefixDefault;

    public string LayoutVariationPrefix
    {
        get => _layoutVariationPrefix ??= $"{LayoutPrefix}variation-";
        set => _layoutVariationPrefix = value;
    }

    public string LayoutAdminContainer
    {
        get => _layoutAdminContainer ??= $"{LayoutPrefix}admin-container";
        set => _layoutAdminContainer = value;
    }

    public string PanePrefix { get; set; } = PanePrefixDefault;

    public string PaneIsEmpty
    {
        get => _paneIsEmpty ??= $"{PanePrefix}is-empty";
        set => _paneIsEmpty = value;
    }

    public string ModulePrefix { get; set; } = ModulePrefixDefault;

    public string ModuleUnpublished
    {
        get => _moduleUnpublished ??= $"{ModulePrefixDefault}unpublished";
        set => _moduleUnpublished = value;
    }
}