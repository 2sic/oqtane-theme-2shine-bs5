﻿using System.Collections.Generic;
using ToSic.Oqt.Themes.ToShineBs5.Client.Models;
using ToSic.Oqt.Themes.ToShineBs5.Client.Services;

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

    public const string PlaceHolderPageId = "PAGEID";
    public const int PlaceHolderLevelOther = -1;

    public const string MenuDefault = "Main";
    public const string MenuMobile = "Mobile";
    public const string MenuSidebar = "Sidebar";
    public const string MenuDesignDefault = "Default";

    // TODO: Review if we should have a menu-id, as otherwise multiple menus open/collapse together

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
    
    public static Dictionary<string, MenuDesign> MenuDesignDefaults = new()
    {
        { MenuDefault, MenuDesignFallback },
        {
            MenuMobile, new()
            {
                Parts = new()
                {
                    {
                        "a", new()
                        {
                            Classes = "nav-link mobile-navigation-link",
                            Active = "active",
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
                        "ul", new()
                        {
                            ByLevel = new()
                            {
                                // Standard navbar-nav BS5
                                { 0, "navbar-nav" },
                                // todo: doc why collapse-PageId
                                { PlaceHolderLevelOther, $"collapse to-shine-submenu-mob-{PlaceHolderPageId}" },
                            },
                        }
                    },
                },
            }
        },
        {
            MenuSidebar, new()
            {
                Parts = new()
                {
                    {
                        "a", new()
                        {
                            Classes = "nav-link",
                            Active = "active",
                        }
                    },
                    {
                        "li", new()
                        {
                            Classes = $"nav-item nav-{PlaceHolderPageId} position-relative",
                            HasChildren = "has-child",
                            Active = "active",
                            Disabled = "disabled",
                        }
                    },
                    {
                        "ul", new()
                        {
                            ByLevel = new()
                            {
                                { 0, "navbar-nav" },
                                { PlaceHolderLevelOther, $"collapse to-shine-submenu-{PlaceHolderPageId}" },
                            },
                        }
                    },
                },
            }
        },
    };
}