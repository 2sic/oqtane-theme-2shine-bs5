namespace ToSic.Oqt.Themes.ToShineBs5.Client.Internal.Menu;

public class MenuConfig: IMenuConfig
{

    /// <summary>
    /// Empty constructor is important for JSON deserialization
    /// </summary>
    public MenuConfig() { }

    public MenuConfig(IMenuConfig original)
    {
        Id = original.Id;
        ConfigName = original.ConfigName;
        Debug = original.Debug;
        Display = original.Display;
        Depth = original.Depth;
        Children = original.Children;
        //NavClasses = original.NavClasses;
        PageList = original.PageList;
        Start = original.Start;
        Level = original.Level;

        Design = original.Design;
        MenuCss = (original as MenuConfig)?.MenuCss;
    }

    public MenuConfig Overrule(MenuConfig overrule)
    {
        var newMc = new MenuConfig(this);
        if (overrule == null) return newMc;
        if (!string.IsNullOrWhiteSpace(overrule.Id)) newMc.Id = overrule.Id;
        if (overrule.ConfigName != default) newMc.ConfigName = overrule.ConfigName;
        if (overrule.Debug != default) newMc.Debug = overrule.Debug;
        if (overrule.Display != default) newMc.Display = overrule.Display;
        if (overrule.Depth != default) newMc.Depth = overrule.Depth;
        if (overrule.Children != default) newMc.Children = overrule.Children;
        // NavClasses
        if (overrule.PageList != default) newMc.PageList = overrule.PageList;
        if (overrule.Start != default) newMc.Start = overrule.Start;
        if (overrule.Level != default) newMc.Level = overrule.Level;

        if (overrule.Design != default) newMc.Design = overrule.Design;
        // var typed = overrule as MenuConfig;
        if (overrule.MenuCss != default) newMc.MenuCss = overrule.MenuCss;
        return newMc;
    }

    /// <inheritdoc />
    public string Id { get; set; }

    /// <inheritdoc />
    public string ConfigName { get; set; }
    //public const string ConfigNameDefault = "Main";

    /// <inheritdoc />
    public bool Debug { get; set; } = DebugDefault;

    public const bool DebugDefault = false;

    //public string NavClasses { get; set; }

    /// <inheritdoc />
    public bool? Display { get; set; } = true;
    public const bool DisplayDefault = true;

    /// <inheritdoc />
    public int? Depth { get; set; } = 0;
    public const int LevelDepthDefault = default;

    /// <inheritdoc />
    public bool? Children { get; set; }
    public const bool ChildrenDefault = default;

    /// <inheritdoc />
    public List<int> PageList { get; set; }

    /// <inheritdoc />
    public string Start { get; set; }
    public const string StartPageDefault = "*";
    public const string StartPageRoot = "*";
    public const string StartPageCurrent = ".";

    /// <inheritdoc />
    public int? Level { get; set; }
    public const int StartLevelDefault = default;

    public string Design { get; set; }

    //public List<StartingPoint> StartingPoints
    //{
    //    get
    //    {
    //        if (_startingPoints != null) return _startingPoints;

    //        // build starting points
    //        var startParts = (Start ?? StartPageDefault).Split(',');

    //        return _startingPoints;
    //    }
    //    set => _startingPoints = value;
    //}

    //private List<StartingPoint> _startingPoints;

    // todo: name, maybe not on interface
    public MenuDesign MenuCss { get; set; }
}