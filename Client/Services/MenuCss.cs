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
        Configs = new List<MenuCssConfig> { MenuCssDefaultsTODOMergeIn, config };
    }
    internal List<MenuCssConfig> Configs { get; }

    public Func<MenuBranch, string> LinkCustom;
    public Func<MenuBranch, string> ItemCustom;

    public string ClassesA(MenuBranch branch)
    {
        var classes = TagClasses("a", branch, Configs.Select(c => c.A), LinkCustom);

        return ListToClasses(classes, branch.Page.PageId);
    }
    public string ClassesUl(MenuBranch branch)
    {
        var classes = TagClasses("ul", branch, Configs.Select(c => c.Ul), null);

        return ListToClasses(classes, branch.Page.PageId);
    }

    private List<string> TagClasses(string tag, MenuBranch branch, IEnumerable<MenuCssTagConfig> tagConfigs, Func<MenuBranch, string> custom)
    {
        var configs = tagConfigs
            .Where(c => c != null)
            .ToList();

        var classes = new List<string>();
        classes.AddRange(configs.Select(c => c.Classes));

        classes.AddRange(configs.Select(c
            => branch.IsActive ? c.Active : c.NotActive));

        classes.AddRange(configs.Select(c
            => branch.HasChildren ? c.HasChildren : c.NoChildren));
        classes.AddRange(configs.Select(c
            => branch.Page.IsClickable ? c.Enabled : c.Disabled));

        // See if there are any css for this level or for not-specified levels
        var levelCss = configs
            .Select(c => c.ByLevel == null
                ? null
                : c.ByLevel.TryGetValue(branch.MenuLevel, out var levelClasses)
                    ? levelClasses
                    : c.ByLevel.TryGetValue(PlaceHolderLevelOther, out var levelClassesDefault)
                        ? levelClassesDefault
                        : null);
        classes.AddRange(levelCss);

        if (custom != null)
            classes.Add(custom.Invoke(branch));

        return classes;
    }

    public string ClassesLi(MenuBranch branch)
    {
        var classes = new List<string>();
        classes.AddRange(CommonLiClasses(branch));

        classes.AddRange(TagClasses("li", branch, Configs.Select(c => c.Li), ItemCustom));

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