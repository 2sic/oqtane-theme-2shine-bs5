using Oqtane.UI;

namespace ToSic.Oqt.Cre8Magic.Client;

public class MagicPlaceholders
{
    /// <summary>
    /// This will be used as value if a value is null/empty.
    /// For example, it would give a page-parent-none if there is no parent
    /// </summary>
    public const string None = "none";
    public const string PlaceholderMarker = "[";


    public const string PageId = "[Page.Id]";
    public const string SiteId = "[Site.Id]";
    public const string PageParentId = "[Page.ParentId]";
    public const string PageRootId = "[Page.RootId]";
    public const string AssetsPath = "[Assets.Path]";
    public const string MenuId = "[Menu.Id]";
    public const string MenuLevel = "[Menu.Level]";
    public const string LayoutVariation = "[Layout.Variation]";
    
    /// <summary>
    /// Special key to mark rules "ByLevel" which apply to all level which had not been defined
    /// </summary>
    public const int ByLevelOtherKey = -1;

    internal static string Replace(string classes, PageState pageState, string layoutVariation) 
        => new PagePlaceholders(pageState, layoutVariation: layoutVariation).Replace(classes);
}