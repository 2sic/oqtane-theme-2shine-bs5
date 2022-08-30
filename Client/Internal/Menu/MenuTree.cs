using System;
using System.Diagnostics.CodeAnalysis;
using Oqtane.Models;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Internal.Menu;

public class MenuTree : MenuBranch
{
    public const char PageForced = '!';

    internal IMenuConfig Config { get; }
    internal List<Page> AllPages { get; }

    /// <summary>
    /// Pages in the menu according to Oqtane pre-processing
    /// Should be limited to pages which should be in the menu, visible and permissions ok. 
    /// </summary>
    internal List<Page> MenuPages;

    protected override MenuTree Tree => this;

    internal MenuCss Design => _menuCss ??= new MenuCss((Config as MenuConfig)?.MenuCss);
    private MenuCss _menuCss;

    public override string Debug { get; }

    public MenuTree([NotNull] IMenuConfig config, [NotNull] List<Page> allPages, [NotNull] List<Page> menuPages, [NotNull] Page page, string debug)
        : base(null, 0, page)
    {
        Config = config;
        AllPages = allPages;
        MenuPages = menuPages;
        Debug = debug;

        // Bug in Oqtane 3.2 and before: Level isn't hydrated
        if (allPages.All(p => p.Level == 0))
            MenuPatchCode.GetPagesHierarchy(allPages);
    }

    [return: NotNull]
    protected override List<Page> GetChildPages()
    {
        // Give empty list if we shouldn't display it
        if (Config.Display == false) return new();

        // Fake code to be able to stop at specific menus for testing
        if (Config.Debug)
            Config.Debug = Config.Debug;

        // Case 1: StartPage *, so all top-level entries
        var start = Config.Start?.Trim();

        // Case 2: '.' - not yet tested
        var startLevel = Config.Level ?? MenuConfig.StartLevelDefault;
        var getChildren = Config.Children ?? MenuConfig.ChildrenDefault;
        var startingPoints = ConfigToStartingPoints(start, startLevel, getChildren);
        // Case 3: one or more IDs to start from

        var startPages = FindStartPages(startingPoints);

        return startPages;
    }

    internal List<Page> FindStartPages(StartingPoint[] pageIds)
    {
        return pageIds.SelectMany(n =>
            {
                var source = n.Force ? Tree.AllPages : Tree.MenuPages;
                
                // Start by getting all the anchors - the pages to start from, before we know about children or not
                // Three cases: root, current, ...
                var anchors = n.Id != default
                    ? source.Where(p => p.PageId == n.Id).ToList()
                    : n.From == MenuConfig.StartPageRoot
                        ? source.Where(p => p.Level == n.Level).ToList()
                        : null;

                if (anchors == null && n.From == MenuConfig.StartPageCurrent)
                    if (n.Level == 0)
                        anchors = new List<Page> { Page };
                    else
                    {
                        var ancestors = source.GetAncestors(Page);
                        if (n.Level > 0) ancestors = ancestors.Reverse();
                        anchors = ancestors.Skip(Math.Abs(n.Level)).ToList();
                    }

                anchors ??= new List<Page>();

                return n.Children
                    ? anchors.SelectMany(p => GetRelatedPagesByLevel(p, 1)).ToList()
                    : anchors;
            })
            .Where(p => p != null)
            .ToList();
    }


    private List<Page> GetRelatedPagesByLevel(Page referencePage, int level)
    {
        switch (level)
        {
            case -1:
                return ChildrenOf(referencePage.ParentId ?? 0);
            case 0:
                return new List<Page> { referencePage };
            case 1:
                return ChildrenOf(referencePage.PageId);
            case > 1:
                return new List<Page> { ErrPage(0, "Error: Create menu from current page but level > 1") };
            default:
                return new List<Page>
                    { ErrPage(0, "Error: Create menu from current page but level < -1, not yet implemented") };
        }
    }

    private StartingPoint[] ConfigToStartingPoints(string value, int level, bool children)
    {
        if (string.IsNullOrWhiteSpace(value)) return Array.Empty<StartingPoint>();
        var parts = value.Split(',');
        var result = parts
            .Select(fromNode =>
            {
                fromNode = fromNode.Trim();
                if (string.IsNullOrWhiteSpace(fromNode)) return null;
                var important = fromNode.EndsWith(PageForced);
                if (important) fromNode = fromNode.TrimEnd(PageForced);
                fromNode = fromNode.Trim();
                int.TryParse(fromNode, out var id);
                return new StartingPoint { Id = id, From = fromNode, Force = important, Children = children, Level = level};
            })
            .Where(n => n != default)
            .ToArray();
        return result;
    }
}