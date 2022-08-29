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
        Configs = new List<MenuCssConfig> { config };
    }
    internal List<MenuCssConfig> Configs { get; }

    public string Classes(string tag, MenuBranch branch)
    {
        var configsForTag = Configs
            .Select(c => c.Parts.TryGetValue(tag, out var a) ? a : null)
            .Where(c => c != null)
            .ToList();

        return configsForTag.Any() 
            ? ListToClasses(TagClasses(branch, configsForTag), branch.Page.PageId) 
            : "";
    }

    private List<string> TagClasses(MenuBranch branch, IEnumerable<MenuCssTagConfig> tagConfigs)
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

        // First/Last ATM not implemented
        // as it should be doable with CSS li:first-child() etc.
        //classes.AddRange(configs.Select(c
        //    => branch.Page.Order == 1 ? c.OrderIsFirst : null));

        return classes;
    }

    

    private string ListToClasses(IEnumerable<string> original, int pageId) 
        => string
            .Join(" ", original.Where(s => !s.IsNullOrEmpty()))
            .Replace("  ", " ")
            .Replace(PlaceHolderPageId, pageId.ToString());


}