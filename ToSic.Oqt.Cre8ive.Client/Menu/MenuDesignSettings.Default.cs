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
        Styling = new()
        {
            {
                "a", new()
                {
                    IsActive = "active",
                    IsParent = "dropdown-toggle",
                    ByLevel = new()
                    {
                        { ByLevelOtherKey, "dropdown-item" },
                        { 1, "nav-link" },

                    }
                }
            },
            {
                "li", new()
                {
                    Classes = $"nav-item nav-{PageId}",
                    IsParent = "has-child dropdown",
                    IsActive = "active",
                    IsDisabled = "disabled",
                }

            },
            {
                "ul", new()
                {
                    ByLevel = new()
                    {
                        { ByLevelOtherKey, "dropdown-menu" },
                        { 0, "navbar-nav" },
                    },
                }
            }
        },
    };
}