using Oqtane.Models;
using System.Collections.Generic;

namespace ToSic.Oqt.Themes.ToShineBs5.Client;

public class JsonNav
{
    public Dictionary<string, JasonMenuConfig> NavConfigs { get; set; }

    public Dictionary<string, Dictionary<string, string>> NavClasses { get; set; }
}

public class JasonMenuConfig
{
    public int? Levels { get; set; }
    public Page ParentPage { get; set; }

    public string NavClasses { get; set; }
}