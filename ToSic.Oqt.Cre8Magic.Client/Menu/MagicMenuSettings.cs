namespace ToSic.Oqt.Cre8Magic.Client.Menu;

public class MagicMenuSettings: IMagicMenuSettings
{

    /// <summary>
    /// Empty constructor is important for JSON deserialization
    /// </summary>
    public MagicMenuSettings() { }

    public MagicMenuSettings(IMagicMenuSettings original)
    {
        Id = original.Id;
        ConfigName = original.ConfigName;
        Debug = original.Debug;
        Display = original.Display;
        Depth = original.Depth;
        Children = original.Children;
        PageList = original.PageList;
        Start = original.Start;
        Level = original.Level;

        Design = original.Design;
        DesignSettings = (original as MagicMenuSettings)?.DesignSettings;
    }

    public MagicMenuSettings Overrule(MagicMenuSettings? overrule)
    {
        var newMc = new MagicMenuSettings(this);
        if (overrule == null) return newMc;
        if (!string.IsNullOrWhiteSpace(overrule.Id)) newMc.Id = overrule.Id;
        if (overrule.ConfigName != default) newMc.ConfigName = overrule.ConfigName;
        if (overrule.Debug != default) newMc.Debug = overrule.Debug;
        if (overrule.Display != default) newMc.Display = overrule.Display;
        if (overrule.Depth != default) newMc.Depth = overrule.Depth;
        if (overrule.Children != default) newMc.Children = overrule.Children;
        if (overrule.PageList != default) newMc.PageList = overrule.PageList;
        if (overrule.Start != default) newMc.Start = overrule.Start;
        if (overrule.Level != default) newMc.Level = overrule.Level;

        if (overrule.Design != default) newMc.Design = overrule.Design;
        if (overrule.DesignSettings != default) newMc.DesignSettings = overrule.DesignSettings;
        return newMc;
    }

    /// <inheritdoc />
    public string? Id { get; set; }

    /// <inheritdoc />
    public string? ConfigName { get; set; }

    /// <inheritdoc />
    public bool Debug { get; set; } = DebugDefault;

    public const bool DebugDefault = false;

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
    public List<int>? PageList { get; set; }

    /// <inheritdoc />
    public string? Start { get; set; }
    public const string StartPageDefault = "*";
    public const string StartPageRoot = "*";
    public const string StartPageCurrent = ".";

    /// <inheritdoc />
    public int? Level { get; set; }
    public const int StartLevelDefault = default;

    public string? Design { get; set; }

    // todo: name, maybe not on interface
    public MagicMenuDesignSettings? DesignSettings { get; set; }

    public string MenuId => _menuId ??= string.IsNullOrWhiteSpace(Id)
        ? new Random().Next(100000, 1000000).ToString()
        : Id;
    private string? _menuId;


    public static MagicMenuSettings Defaults = new()
    {
        Start = "*",
        Depth = 0,
    };
}