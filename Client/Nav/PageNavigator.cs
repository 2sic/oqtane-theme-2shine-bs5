using Oqtane.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Nav;

public class PageNavigator
{
    public virtual PageNavigatorRoot RootNavigator { get; }

    public Page CurrentPage;

    public int NavigationLevel;

    public int LevelCounter;

    public PageNavigator(PageNavigatorRoot rootNavigator, int navigationLevel, int levelDepth, [NotNull] Page currentPage)
    {
        RootNavigator = rootNavigator;
        CurrentPage = currentPage;
        LevelCounter = levelDepth;
        NavigationLevel = navigationLevel;
    }

    public bool HasChildren => Children.Any();

    [NotNull]
    public IList<PageNavigator> Children
    {
        get => _children ??= GetChildren();
        protected set => _children = value;
    }
    private IList<PageNavigator> _children;

    [return: NotNull]
    protected virtual List<PageNavigator> GetChildren()
    {
        if (LevelCounter <= 0) return new List<PageNavigator>();

        var level = NavigationLevel + 1;
        var remainingLevels = LevelCounter - 1;

        //var childPages = CurrentPage != null 
        //    ? RootNavigator.MenuPages.Where(p => p.ParentId == CurrentPage.PageId) 
        //    : RootNavigator.MenuPages.Where(p => p.ParentId == null);

        return GetChildPages() // childPages
            .Select(page => new PageNavigator(RootNavigator, level, remainingLevels, page))
            .ToList();
    }

    protected virtual List<Page> GetChildPages()
    {
        return CurrentPage == null
            ? new List<Page> { ErrPage(-1, "Error: No current page found") }
            : ChildrenOf(CurrentPage.PageId); // RootNavigator.MenuPages.Where(p => p.ParentId == CurrentPage.PageId).ToList();
    }

    protected List<Page> ChildrenOf(int pageId)
        => RootNavigator.MenuPages.Where(p => p.ParentId == pageId).ToList();

    protected List<Page> FindPages(int[] pageIds)
        => RootNavigator.MenuPages.Where(p => pageIds.Contains(p.PageId)).ToList();

    protected static Page ErrPage(int id, string message)
        => new Page { PageId = id, Name = message };

}