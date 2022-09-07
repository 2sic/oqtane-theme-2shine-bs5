﻿namespace ToSic.Oqt.Cre8Magic.Client.Menu;
using static Placeholders;

public partial class MenuDesign
{
    /// <summary>
    /// The default/fallback design configuration for menus.
    /// Normally this would be set in the json file or the theme settings, so this wouldn't be used. 
    /// </summary>
    public static MenuDesign Defaults => new()
    {
        Styling = new()
        {
            {
                "a", new()
                {
                    IsActive = "active",
                    HasChildren = "dropdown-toggle",
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
                    HasChildren = "has-child dropdown",
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