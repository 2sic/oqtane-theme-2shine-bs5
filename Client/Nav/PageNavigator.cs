using Oqtane.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Nav;

public class PageNavigator
{
    public IEnumerable<Page> Pages;

    public Page CurrentPage;

    public int NavigationLevel;

    public int LevelCounter;

    public PageNavigator(IEnumerable<Page> pages, int navigationLevel, int levelDepth, Page currentPage, IList<PageNavigator> children = null)
    {
        CurrentPage = currentPage;
        Pages = pages;
        LevelCounter = levelDepth;
        NavigationLevel = navigationLevel;
        _children = children;
    }

    public bool HasChildren => Children.Any();

    public IList<PageNavigator> Children => _children ??= GetChildren().ToList();
    private IList<PageNavigator> _children;

    private IEnumerable<PageNavigator> GetChildren()
    {
        if (LevelCounter <= 0) return new List<PageNavigator>();

        var level = NavigationLevel + 1;
        LevelCounter--;

        var childPages = CurrentPage != null 
            ? Pages.Where(p => p.ParentId == CurrentPage.PageId) 
            : Pages.Where(p => p.ParentId == null);

        return childPages.Select(p => new PageNavigator(Pages, level, LevelCounter, p));

    }
}