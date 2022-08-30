using System.Collections.Generic;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Internal.Menu;

public class MenuConfigJson
{
    /// <summary>
    /// The menu definitions
    /// </summary>
    public Dictionary<string, MenuConfig> Menus { get; set; } = new();

    /// <summary>
    /// Design definitions of the menu
    /// </summary>
    public Dictionary<string, MenuDesign> Designs { get; set; } = new();
}