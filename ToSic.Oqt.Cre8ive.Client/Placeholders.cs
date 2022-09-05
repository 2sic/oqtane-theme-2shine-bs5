using Oqtane.UI;

namespace ToSic.Oqt.Cre8ive.Client;

public class Placeholders
{
    public const string NoneId = "none";
    public const string PlaceholderMarker = "[";
    public const string PageId = "[Page.Id]";
    public const string SiteId = "[Site.Id]";
    public const string PageParentId = "[Page.ParentId]";
    public const string PageRootId = "[Page.RootId]";
    public const string AssetsPath = "[Assets.Path]";
    public const string MenuId = "[Menu.Id]";
    public const string MenuLevel = "[Menu.Level]";
    public const string LayoutVariation = "[Layout.Variation]";
    public const int PlaceHolderLevelOther = -1;

    internal static string Replace(string classes, PageState pageState, string layoutVariation) 
        => new PagePlaceholders(pageState, layoutVariation: layoutVariation).Replace(classes);
}