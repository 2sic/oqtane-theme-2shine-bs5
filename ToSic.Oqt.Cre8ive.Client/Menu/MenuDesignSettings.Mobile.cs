namespace ToSic.Oqt.Cre8ive.Client.Menu;
using static Placeholders;

public partial class MenuDesignSettings
{
    /// <summary>
    /// The default/fallback design configuration for menus.
    /// Normally this would be set in the json file or the theme settings, so this wouldn't be used. 
    /// </summary>
    public static MenuDesignSettings MobileDefaults = new()
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
    };
}