using Oqtane.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToSic.Oqt.Themes.ToSicStatus.Client.Nav;

public class PageNavigator
{
    public IEnumerable<Page> Pages;

    public Page CurrentPage = null;

    public int NavigationLevel;

    public int LevelCounter;

    public PageNavigator(IEnumerable<Page> pages, int navigationlevel, int leveldepth, Page currentpage, IList<PageNavigator> children = null)
    {
        CurrentPage = currentpage;
        Pages = pages;
        LevelCounter = leveldepth;
        NavigationLevel = navigationlevel;
        _children = children;
    }

    public bool HasChildren => Children.Any();

    public IList<PageNavigator> Children => _children ??= GetChildren().ToList();
    private IList<PageNavigator> _children;

    private IEnumerable<PageNavigator> GetChildren()
    {
        if (LevelCounter > 0)
        {
            var level = NavigationLevel + 1;
            LevelCounter--;

            IEnumerable<Page> childPages;
            if (CurrentPage != null)
            {
                childPages = Pages.Where(p => p.ParentId == CurrentPage.PageId);
            }
            else
            {
                childPages = Pages.Where(p => p.ParentId == null);
            }

            return childPages.Select(p => new PageNavigator(Pages, level, LevelCounter, p));
        }
        else
        {
            return new List<PageNavigator>();
        }
    }
}