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
        Debug = original.Debug;
        Display = original.Display;
        LevelDepth = original.LevelDepth;
        LevelSkip = original.LevelSkip;
        //NavClasses = original.NavClasses;
        PageList = original.PageList;
        Start = original.Start;
        StartLevel = original.StartLevel;
    }

    public MenuConfig Overrule(MenuConfig overrule)
    {
        var newMc = new MenuConfig(this);
        if (overrule.ConfigName != default) newMc.ConfigName = overrule.ConfigName;
        if (overrule.Debug != default) newMc.Debug = overrule.Debug;
        if (overrule.Display != default) newMc.Display = overrule.Display;
        if (overrule.LevelDepth != default) newMc.LevelDepth = overrule.LevelDepth;
        if (overrule.LevelSkip != default) newMc.LevelSkip = overrule.LevelSkip;
        // NavClasses
        if (overrule.PageList != default) newMc.PageList = overrule.PageList;
        if (overrule.Start != default) newMc.Start = overrule.Start;
        if (overrule.StartLevel != default) newMc.StartLevel = overrule.StartLevel;
        return newMc;
    }

    /// <inheritdoc />
    public string ConfigName { get; set; }
    public const string ConfigNameDefault = "Main";

    /// <inheritdoc />
    public bool Debug { get; set; } = DebugDefault;

    public const bool DebugDefault = false;

    //public string NavClasses { get; set; }

    /// <inheritdoc />
    public bool? Display { get; set; } = true;
    public const bool DisplayDefault = true;

    /// <inheritdoc />
    public int? LevelDepth { get; set; } = 0;
    public const int LevelDepthDefault = 0;

    /// <inheritdoc />
    public int? LevelSkip { get; set; } = 0;
    public const int LevelSkipDefault = 0;

    /// <inheritdoc />
    public List<int> PageList { get; set; }

    /// <inheritdoc />
    public string Start { get; set; }
    public const string StartPageDefault = "*";
    public const string StartPageRoot = "*";
    public const string StartPageCurrent = ".";

    /// <inheritdoc />
    public int? StartLevel { get; set; }
    public const int StartLevelDefault = 0;
}