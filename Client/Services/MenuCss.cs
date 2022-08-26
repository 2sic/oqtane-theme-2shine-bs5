using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ToSic.Oqt.Themes.ToShineBs5.Client.Models;
using static ToSic.Oqt.Themes.ToShineBs5.Client.ThemeCss;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services;

/// <summary>
/// Special helper to provide Css classes to menus
/// </summary>
public class MenuCss
{
    public MenuCss(MenuCssConfig config)
    {
        Configs = new List<MenuCssConfig> { MenuCssDefaults, config };
    }
    internal List<MenuCssConfig> Configs { get; }

    public Func<MenuBranch, string> LinkCustom;
    public Func<MenuBranch, string> ItemCustom;

    public string LinkClasses(MenuBranch branch)
    {
        var classes = new List<string>();
        if (LinkCustom != null)
            classes.Add(LinkCustom.Invoke(branch));

        classes.AddRange(Configs.Select(c => c.AClasses));
        classes.AddRange(Configs.Select(c 
            => branch.IsActive ? c.AActive : c.AInactive));
        return ListToClasses(classes);
    }

    public string LiClasses(MenuBranch branch)
    {
        var classes = new List<string>();
        classes.AddRange(CommonLiClasses(branch));
        classes.AddRange(Configs.Select(c => c.LiClasses));

        if (ItemCustom != null)
            classes.Add(ItemCustom.Invoke(branch));

        classes.AddRange(Configs.Select(c
            => branch.IsActive ? c.LiActive : c.LiInactive));

        return ListToClasses(classes);
    }

    private IList<string> CommonLiClasses(MenuBranch branch)
    {
        var commonClasses = new List<string>
        {
            //"nav-item",
            "nav-" + branch.Page.PageId
        };

        if (branch.Page.Order == 1)
            commonClasses.Add("first");

        //if (PageNavigator.CurrentPage.Order == length)
        //    commonClasses.Add("last");

        //commonClasses.Add(branch.IsActive ? "active" : "inactive");

        if (branch.HasChildren)
            commonClasses.Add("has-child");

        if (branch.Page.IsClickable == false)
            commonClasses.Add("disabled");

        return commonClasses;
    }

    private string ListToClasses(IEnumerable<string> original) 
        => string
            .Join(" ", original.Where(s => !s.IsNullOrEmpty()))
            .Replace("  ", " ");




}