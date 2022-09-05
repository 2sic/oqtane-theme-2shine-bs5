﻿using System.Collections;

namespace ToSic.Oqt.Cre8ive.Client.Menu;

/// <summary>
/// Special helper to provide Css classes to menus
/// </summary>
public class MenuCss
{
    public MenuCss(IMenuConfig menuConfig)
    {
        MenuConfig = menuConfig as MenuConfig ?? throw new ArgumentException("MenuConfig must be real", nameof(MenuConfig));

        DesignSettingsList = new List<MenuDesign> { MenuConfig.DesignSettings! };
    }
    private MenuConfig MenuConfig { get; }
    internal List<MenuDesign> DesignSettingsList { get; }

    public string Value(string key, MenuBranch branch)
    {
        var configsForKey = ConfigsForTag(key)
            .Select(c => c.Value)
            .Where(v => v.HasValue())
            .ToList();

        return string.Join(" ", configsForKey);
    }

    public string Classes(string tag, MenuBranch branch)
    {
        var configsForTag = ConfigsForTag(tag);
        return configsForTag.Any()
            ? ListToClasses(TagClasses(branch, configsForTag as List<MenuStyling>))
            : "";
    }

    private List<MenuStyling?> ConfigsForTag(string tag) =>
        DesignSettingsList
            .Select(c => c.Styling.FindInvariant(tag))
            .Where(c => c is not null)
            .ToList();

    private List<string?> TagClasses(MenuBranch branch, List<MenuStyling> configs)
    {
        var classes = new List<string?>();
        classes.AddRange(configs.Select(c => c.Classes));

        classes.AddRange(configs.Select(c
            => branch.IsActive ? c.IsActive : c.IsNotActive));

        classes.AddRange(configs.Select(c
            => branch.HasChildren ? c.HasChildren : c.HasNoChildren));
        classes.AddRange(configs.Select(c
            => branch.Page.IsClickable ? c.IsNotDisabled : c.IsDisabled));

        classes.AddRange(configs.Select(c
            => branch.InBreadcrumb ? c.IsInBreadcrumb : c.IsNotInBreadcrumb));

        // See if there are any css for this level or for not-specified levels
        var levelCss = configs
            .Select(c => c.ByLevel == null
                ? null
                : c.ByLevel.TryGetValue(branch.MenuLevel, out var levelClasses)
                    ? levelClasses
                    : c.ByLevel.TryGetValue(Placeholders.ByLevelOtherKey, out var levelClassesDefault)
                        ? levelClassesDefault
                        : null);
        classes.AddRange(levelCss);

        return classes;
    }



    private string ListToClasses(IEnumerable<string?> original)
        => string.Join(" ", original.Where(s => !s.IsNullOrEmpty())).Replace("  ", " ");
}