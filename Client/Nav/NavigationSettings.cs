using System.Collections.Generic;

namespace ToSic.Oqt.Themes.ToSicStatus.Client.Nav;

public class JsonNav
{
    public Dictionary<string, MenuConfig> NavConfigs { get; set; }
}

public class MenuConfig
{
    /// <summary>
    /// Empty constructor is important for deserialization
    /// </summary>
    public MenuConfig() { }

    public List<int> PageList { get; set; }
    public string StartingPage { get; set; }
    public int? StartLevel { get; set; }

    public int LevelSkip { get; set; } = 0;
    public int? LevelDepth { get; set; }

    public bool Display { get; set; } = true;

    public string Variation { get; set; }
    public string NavClasses { get; set; }

    public MenuConfig(MenuConfig original)
    {
        LevelDepth = original.LevelDepth;
        NavClasses = original.NavClasses;
        StartingPage = original.StartingPage;
        Variation = original.Variation;
        PageList = original.PageList;
    }
}