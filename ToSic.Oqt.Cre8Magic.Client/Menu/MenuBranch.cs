using System.Diagnostics.CodeAnalysis;
using Oqtane.Models;

namespace ToSic.Oqt.Cre8ive.Client.Menu;

public class MenuBranch: IHasSettingsExceptions
{
    /// <summary>
    /// Root navigator object which has some data/logs for all navigators which spawned from it. 
    /// </summary>
    protected virtual MenuTree Tree { get; }

    public string? Classes(string tag) => Tree.PageReplacer.Replace(Tree.Design.Classes(tag, this), Page).EmptyAsNull();

    public string? Value(string key) => Tree.PageReplacer.Replace(Tree.Design.Value(key, this), Page).EmptyAsNull();

    public virtual string? Debug => Tree.Debug;

    /// <summary>
    /// Current Page
    /// </summary>
    public Page Page { get; }

    /// <summary>
    /// Menu Level relative to the start of the menu (always starts with 1)
    /// </summary>
    public int MenuLevel { get; }

    public MenuBranch(MenuTree root, int menuLevel, Page page)
    {
        Tree = root;
        Page = page;
        MenuLevel = menuLevel;
    }

    public bool HasChildren => Children.Any();

    public bool IsActive => Page.PageId == Tree.Page.PageId;

    public bool InBreadcrumb => Tree.Breadcrumb.Contains(Page);

    public virtual string MenuId => Tree.MenuId;

    public IList<MenuBranch> Children => _children ??= GetChildren();
    private IList<MenuBranch>? _children;

    /// <summary>
    /// Retrieve the children the first time it's needed.
    /// </summary>
    /// <returns></returns>
    [return: NotNull]
    protected List<MenuBranch> GetChildren()
    {
        var levelsRemaining = (Tree.Config.Depth ?? MenuConfig.LevelDepthDefault) - MenuLevel + 1;
        return levelsRemaining <= 0
            ? new List<MenuBranch>()
            : GetChildPages()
                .Select(page => new MenuBranch(Tree, MenuLevel + 1, page))
                .ToList();
    }


    protected virtual List<Page> GetChildPages() => Page == null
        ? new List<Page> { ErrPage(-1, "Error: No current page found") }
        : ChildrenOf(Page.PageId);

    protected List<Page> ChildrenOf(int pageId)
        => Tree.MenuPages.Where(p => p.ParentId == pageId).ToList();

    protected List<Page> FindPages(int[] pageIds)
        => Tree.MenuPages.Where(p => pageIds.Contains(p.PageId)).ToList();


    protected static Page ErrPage(int id, string message) => new() { PageId = id, Name = message };

    public virtual List<SettingsException> Exceptions => Tree.Exceptions;
}