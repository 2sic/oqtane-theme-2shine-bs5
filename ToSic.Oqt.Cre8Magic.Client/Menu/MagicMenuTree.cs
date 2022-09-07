using System.Diagnostics.CodeAnalysis;
using Oqtane.Models;
using Oqtane.UI;
using ToSic.Oqt.Cre8Magic.Client.OqtanePatches;

namespace ToSic.Oqt.Cre8Magic.Client.Menu;

public class MagicMenuTree : MagicMenuBranch
{
    public const char PageForced = '!';

    internal IMagicMenuSettings Config { get; }
    public PageState PageState { get; }

    internal PagePlaceholders PageReplacer => _pageReplacer ??= new PagePlaceholders(PageState, null, menuId: MenuId);
    private PagePlaceholders? _pageReplacer;

    /// <summary>
    /// List of all pages - even these which would currently not be shown in the menu.
    /// </summary>
    internal List<Page> AllPages { get; }

    /// <summary>
    /// Pages in the menu according to Oqtane pre-processing
    /// Should be limited to pages which should be in the menu, visible and permissions ok. 
    /// </summary>
    internal List<Page> MenuPages;

    public override List<SettingsException> Exceptions => _exceptions.Exceptions;
    private readonly IHasSettingsExceptions _exceptions;

    protected override MagicMenuTree Tree => this;

    internal MagicMenuDesigner Design => _menuCss ??= new MagicMenuDesigner(Config);
    private MagicMenuDesigner? _menuCss;

    internal List<Page> Breadcrumb => _breadcrumb ??= AllPages.Breadcrumb(Page).ToList();
    private List<Page>? _breadcrumb;

    public override string MenuId => _menuId ??= (Config as MagicMenuSettings)?.MenuId ?? "error-menu-id";
    private string? _menuId;

    public override string? Debug { get; }

    public MagicMenuTree(IMagicMenuSettings config, PageState pageState, List<Page> menuPages, string? debug, IHasSettingsExceptions exceptions)
        : base(null! /* root must be null, as `Tree` is handled in this class */, 0, pageState.Page)
    {
        PageState = pageState;
        Config = config;
        AllPages = pageState.Pages;
        MenuPages = menuPages;
        _exceptions = exceptions;
        Debug = debug;

        // Bug in Oqtane 3.2 and before: Level isn't hydrated
        if (AllPages.All(p => p.Level == 0))
            MenuPatchCode.GetPagesHierarchy(AllPages);
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
        var startLevel = Config.Level ?? MagicMenuSettings.StartLevelDefault;
        var getChildren = Config.Children ?? MagicMenuSettings.ChildrenDefault;
        var startingPoints = ConfigToStartingPoints(start, startLevel, getChildren);
        // Case 3: one or more IDs to start from

        var startPages = FindStartPages(startingPoints);

        return startPages;
    }

    internal List<Page> FindStartPages(StartingPoint[] pageIds)
    {
        var result = pageIds.SelectMany(FindStartingPage)
            .Where(p => p != null)
            .ToList();
        return result;
    }

    private IEnumerable<Page> FindStartingPage(StartingPoint n)
    {
        var source = n.Force ? Tree.AllPages : Tree.MenuPages;

        // Start by getting all the anchors - the pages to start from, before we know about children or not
        // Three cases: root, current, ...
        var anchors = n.Id != default
            ? source.Where(p => p.PageId == n.Id).ToList()
            : n.From == MagicMenuSettings.StartPageRoot
                ? source.Where(p => p.Level == 0).ToList()
                : null;

        if (anchors == null && n.From == MagicMenuSettings.StartPageCurrent)
            // Level 0 means current level / current page
            if (n.Level == 0)
                anchors = new List<Page> { Page };
            // Level 1 means top-level pages. If we don't want the level1 children, we want the top-level items
            // TODO: CHECK WHAT LEVEL Oqtane actually gives us, is 1 the top?
            else if (n.Level == 1 && !n.Children)
                anchors = source.Where(p => p.Level == 0).ToList();
            else
            {
                var ancestors = source.GetAncestors(Page);
                if (n.Level > 0) ancestors = ancestors.Reverse();
                // If coming from the top, level 1 means top level, so skip one less
                var level = n.Level > 0 ? n.Level - 1 : Math.Abs(n.Level);
                anchors = ancestors.Skip(level).ToList();
            }

        anchors ??= new List<Page>();

        return n.Children
            ? anchors.SelectMany(p => GetRelatedPagesByLevel(p, 1)).ToList()
            : anchors;
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

    private StartingPoint[] ConfigToStartingPoints(string? value, int level, bool children)
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
            .Where(n => n != null)
            .ToArray();
        return result as StartingPoint[];
    }
}