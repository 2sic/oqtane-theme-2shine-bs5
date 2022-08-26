using System.Collections.Generic;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Models;

public class MenuConfig: IMenuConfig
{
    /// <summary>
    /// Empty constructor is important for deserialization
    /// </summary>
    public MenuConfig() { }

    public MenuConfig(IMenuConfig original)
    {
        ConfigName = original.ConfigName;
        Display = original.Display;
        LevelDepth = original.LevelDepth;
        LevelSkip = original.LevelSkip;
        //NavClasses = original.NavClasses;
        PageList = original.PageList;
        StartPage = original.StartPage;
        StartLevel = original.StartLevel;
    }

    public MenuConfig Overrule(MenuConfig overrule)
    {
        var newMc = new MenuConfig(this);
        if (overrule.ConfigName != default) newMc.ConfigName = overrule.ConfigName;
        if (overrule.Display != default) newMc.Display = overrule.Display;
        if (overrule.LevelDepth != default) newMc.LevelDepth = overrule.LevelDepth;
        if (overrule.LevelSkip != default) newMc.LevelSkip = overrule.LevelSkip;
        // NavClasses
        if (overrule.PageList != default) newMc.PageList = overrule.PageList;
        if (overrule.StartPage != default) newMc.StartPage = overrule.StartPage;
        if (overrule.StartLevel != default) newMc.StartLevel = overrule.StartLevel;
        return newMc;
    }

    public string ConfigName { get; set; }
    public const string ConfigNameDefault = "Main";
    //public string NavClasses { get; set; }

    public bool? Display { get; set; } = true;
    public const bool DisplayDefault = true;

    public int? LevelDepth { get; set; } = 0;
    public const int LevelDepthDefault = 0;

    public int? LevelSkip { get; set; } = 0;
    public const int LevelSkipDefault = 0;

    public List<int> PageList { get; set; }

    public string StartPage { get; set; }
    public const string StartPageDefault = "*";

    public int? StartLevel { get; set; }
    public int StartLevelDefault = 0;
}