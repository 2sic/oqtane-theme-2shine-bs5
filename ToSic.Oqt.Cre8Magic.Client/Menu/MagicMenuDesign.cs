using ToSic.Oqt.Cre8Magic.Client.Styling;

namespace ToSic.Oqt.Cre8Magic.Client.Menu;

public class MagicMenuDesign: MagicDesignWithActive
{
    /// <summary>
    /// List of classes to add on certain levels only.
    /// Use level -1 to specify classes to apply to all the remaining ones which are not explicitly listed.
    /// </summary>
    public Dictionary<int, string>? ByLevel { get; set; }

    /// <summary>
    /// Classes to add if this node is a parent (has-children).
    ///
    /// Note that we used `IsParent` instead of `HasChildren` to keep naming with `IsNotParent` consistent. 
    /// </summary>
    public string? HasChildren { get; set; }

    /// <summary>
    /// Classes to add if this node is not a parent (doesn't have children)
    /// </summary>
    public string? HasNoChildren { get; set; }

    /// <summary>
    /// Classes to add if the node is disabled.
    /// TODO: unclear why it's disabled, what would cause this...
    /// </summary>
    public string? IsDisabled { get; set; }
    public string? IsNotDisabled { get; set; }

    /// <summary>
    /// Classes to add if this node is in the path / breadcrumb of the current page.
    /// </summary>
    public string? IsInBreadcrumb { get; set; }
    public string? IsNotInBreadcrumb { get; set; }


    /// <summary>
    /// Special key to get a value - for non-css configurations
    /// </summary>
    public string? Value { get; set; }
}