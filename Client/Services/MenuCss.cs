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
        Config = config ?? new MenuCssConfig();
    }

    public Func<MenuBranch, string> LinkCustom;

    public string LinkClasses(MenuBranch branch)
    {
        var initial = new List<string>();
        if (LinkCustom != null)
            initial.Add(LinkCustom.Invoke(branch));

        //var initial = MainAClasses(branch);
        initial.AddRange(Configs.Select(c => c.LinkClasses));
        if (branch.IsActive) 
            initial.AddRange(Configs.Select(c => c.LinkActive));
        return ListToClasses(initial);
    }

    public string ListToClasses(IEnumerable<string> original) => string.Join(" ", original.Where(s => !s.IsNullOrEmpty()));

    internal MenuCssConfig Config { get; set; }

    internal List<MenuCssConfig> Configs => _allConfigs ??= new List<MenuCssConfig> { MenuCssDefaults, Config };
    private List<MenuCssConfig> _allConfigs;



}