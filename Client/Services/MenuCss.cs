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
        //var classes = new List<string>();
        ////if (LinkCustom != null)
        ////    classes.Add(LinkCustom.Invoke(branch));

        //classes.AddRange(TagClasses(branch, Configs.Select(c => c.A), LinkCustom));
        var classes = TagClasses(branch, Configs.Select(c => c.A), LinkCustom);

        return ListToClasses(classes, branch.Page.PageId);
    }

    private List<string> TagClasses(MenuBranch branch, IEnumerable<MenuCssTagConfig> config, Func<MenuBranch, string> custom)
    {
        var confs = config
            .Where(c => c != null)
            .ToList();

        var classes = new List<string>();
        classes.AddRange(confs.Select(c => c.Classes));

        classes.AddRange(confs.Select(c
            => branch.IsActive ? c.Active : c.NotActive));

        classes.AddRange(confs.Select(c
            => branch.HasChildren ? c.HasChildren : c.NoChildren));
        classes.AddRange(confs.Select(c
            => branch.Page.IsClickable ? c.Enabled : c.Disabled));

        if (custom != null)
            classes.Add(custom.Invoke(branch));

        return classes;
    }

    public string LiClasses(MenuBranch branch)
    {
        var classes = new List<string>();
        classes.AddRange(CommonLiClasses(branch));

        classes.AddRange(TagClasses(branch, Configs.Select(c => c.Li), ItemCustom));

        //if (ItemCustom != null)
        //    classes.Add(ItemCustom.Invoke(branch));


        return ListToClasses(classes, branch.Page.PageId);
    }

    private IList<string> CommonLiClasses(MenuBranch branch)
    {
        var commonClasses = new List<string>();

        if (branch.Page.Order == 1)
            commonClasses.Add("first");

        return commonClasses;
    }

    private string ListToClasses(IEnumerable<string> original, int pageId) 
        => string
            .Join(" ", original.Where(s => !s.IsNullOrEmpty()))
            .Replace("  ", " ")
            .Replace(PlaceHolderPageId, pageId.ToString());


}