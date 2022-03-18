using System.Collections.Generic;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Nav;

public class JsonNav
{
    public Dictionary<string, MenuConfig> NavConfigs { get; set; }

    public Dictionary<string, Dictionary<string, string>> NavClasses { get; set; }
}

public class MenuConfig
{
    /// <summary>
    /// Empty constructor is important for deserialization
    /// </summary>
    public MenuConfig() { }

    public int? Levels { get; set; }

    public string ParentPage { get; set; }

    public string NavClasses { get; set; }

    public string Variation { get; set; }
    public MenuConfig(MenuConfig original)
    {
        Levels = original.Levels;
        NavClasses = original.NavClasses;
        ParentPage = original.ParentPage;
        Variation = original.Variation;
    }
}