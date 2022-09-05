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
        Styling = new()
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
                    IsInBreadcrumb = "show",
                }
            },
            {
                "li", new()
                {
                    Classes = $"nav-item nav-{PageId} position-relative",
                    IsParent = "has-child",
                    // todo: make sure that all the LIs or ULs in the breadcrumb don't have collapse ... or with "show"
                    IsActive = "active",
                    IsDisabled = "disabled",
                }
            },
            {
                "a", new()
                {
                    Classes = "nav-link mobile-navigation-link",
                    IsActive = "active",
                }
            },
            {
                "span", new()
                {
                    Classes = "nav-item-sub-opener",
                    IsNotInBreadcrumb = "collapsed",
                }
            },
        },
    };
}