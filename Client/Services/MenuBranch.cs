using Oqtane.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ToSic.Oqt.Themes.ToShineBs5.Client.Models;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services;

public class MenuBranch
{
    /// <summary>
    /// Root navigator object which has some data/logs for all navigators which spawned from it. 
    /// </summary>
    protected virtual MenuTree Tree { get; }

    /// <summary>
    /// Current Page
    /// </summary>
    public Page Page { get; }

    /// <summary>
    /// Menu Level relative to the start of the menu (always starts with 1)
    /// </summary>
    public int MenuLevel { get; }

    public MenuBranch(MenuTree root, int menuLevel, [NotNull] Page page)
    {
        Tree = root;
        Page = page;
        MenuLevel = menuLevel;
    }

    public bool HasChildren => Children.Any();

    [NotNull]
    public IList<MenuBranch> Children => _children ??= GetChildren();
    private IList<MenuBranch> _children;

    /// <summary>
    /// Retrieve the children the first time it's needed.
    /// </summary>
    /// <returns></returns>
    [return: NotNull]
    protected List<MenuBranch> GetChildren()
    {
        var levelsRemaining = (Tree.Config.LevelDepth ?? MenuConfig.LevelDepthDefault) - MenuLevel + 1;
        return levelsRemaining <= 0
            ? new List<MenuBranch>()
            : GetChildPages()
                .Select(page => new MenuBranch(Tree, MenuLevel + 1, page))
                .ToList();
    }




    protected virtual List<Page> GetChildPages()
    {
        return Page == null
            ? new List<Page> { ErrPage(-1, "Error: No current page found") }
            : ChildrenOf(Page.PageId);
    }

    protected List<Page> ChildrenOf(int pageId)
        => Tree.MenuPages.Where(p => p.ParentId == pageId).ToList();

    protected List<Page> FindPages(int[] pageIds)
        => Tree.MenuPages.Where(p => pageIds.Contains(p.PageId)).ToList();

    protected static Page ErrPage(int id, string message) => new() { PageId = id, Name = message };

}