using System.Collections.Generic;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Models;

public class MenuConfigCatalog
{
    /// <summary>
    /// The catalog - must match the name in the json file
    /// </summary>
    public Dictionary<string, MenuConfig> Configurations { get; set; } = new();
}