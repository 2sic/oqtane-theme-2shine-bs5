namespace ToSic.Oqt.Cre8ive.Client.Menu;
using static Placeholders;

public partial class MenuDesignSettings
{
    /// <summary>
    /// The default/fallback design configuration for menus.
    /// Normally this would be set in the json file or the theme settings, so this wouldn't be used. 
    /// </summary>
    public static MenuDesignSettings Defaults => new()
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
}