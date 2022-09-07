namespace ToSic.Oqt.Cre8Magic.Client.Menu;
using static Placeholders;

public partial class MagicMenuDesignSettings
{
    /// <summary>
    /// The default/fallback design configuration for menus.
    /// Normally this would be set in the json file or the theme settings, so this wouldn't be used. 
    /// </summary>
    public static MagicMenuDesignSettings MobileDefaults = new()
    {
        //Design = new()
        //{
            {
                "ul", new()
                {
                    ByLevel = new()
                    {
                        { 0, "navbar-nav" },
                        // todo: doc why collapse-PageId
                        { ByLevelOtherKey, $"collapse to-shine-submenu-{MenuId}-{PageId}" },
                    },
                    IsInBreadcrumb = "show",
                }
            },
            {
                "li", new()
                {
                    Classes = $"nav-item nav-{PageId} position-relative",
                    HasChildren = "has-child",
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
        //},
    };
}