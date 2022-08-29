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

    // TODO: Merge into the other rules
    public static MenuCssConfig MenuCssDefaultsTODOMergeIn = new()
    {
        A = new ()
        {
            Active = "active",
            NotActive = "",
        },
        Li = new()
        {
            Classes = $"nav-item nav-{PlaceHolderPageId}",
            Active = "active",
            NotActive = "inactive",
            HasChildren = "has-child",
            Disabled = "disabled",
        },
    };

    public static MenuCss MenuCssMain = new(new()
        {
            A = new()
            {
                HasChildren = "dropdown-toggle",
                ByLevel = new()
                {
                    { PlaceHolderLevelOther, "dropdown-item" },
                    { 1, "nav-link" },

                }
            },
            Li = new()
            {
                HasChildren = "dropdown",
            },
            Ul = new()
            {
                ByLevel = new()
                {
                    { PlaceHolderLevelOther, "dropdown-menu" },
                    { 0, "navbar-nav" },
                },
            }
        })
        //{
        //    LinkCustom = branch =>
        //    {
        //        var cls = branch.MenuLevel == 1 ? "nav-link" : "dropdown-item";
        //        //if (branch.HasChildren)
        //        //    cls += " dropdown-toggle";
        //        return cls;
        //    },
        //    ItemCustom = branch => branch.HasChildren ? "dropdown" : null
        //}
        ;

    public static MenuCss MenuCssSidebar = new(new()
    {
        A = new()
        {
            Classes = "nav-link",
        },
        Li = new()
        {
            Classes = "position-relative",
        },
        Ul = new()
        {
            ByLevel = new()
            {
                { 0, "navbar-nav" },
                { PlaceHolderLevelOther, $"ul-collapse collapse collapse-{PlaceHolderPageId}" },
            },
        },
    });

    public static MenuCss MenuCssMobile = new(new()
    {
        A = new()
        {
            Classes = "nav-link mobile-navigation-link",
        },
        Li = new()
        {
            Classes = "position-relative",
        },
        Ul = new()
        {
            ByLevel = new()
            {
                { 0, "navbar-nav" },
                { PlaceHolderLevelOther, $"ul-collapse collapse collapse-{PlaceHolderPageId}" },
            },
        },
    });

    public static Dictionary<string, MenuCss> MenuCssDefaults = new()
    {
        { MenuDefault, MenuCssMain },
        { MenuMobile, MenuCssMobile },
        { MenuSidebar, MenuCssSidebar },
    };
}