using Oqtane.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Nav;

public class PageNavigatorService
{
    private IEnumerable<Page> _menuPages;

    private int _levelDepth;

    private int _levelSkip;

    private bool _display;

    public PageNavigator Start(IEnumerable<Page> menuPages, int levelDepth, bool display, int levelSkip, string startingPoint = null, int? startLevel = null, List<int> pageList = null)
    {
        _menuPages = menuPages;
        _levelDepth = levelDepth;
        _levelSkip = levelSkip;
        _display = display;

        var children = DetermineChildren(startingPoint, startLevel, pageList);
        return new PageNavigator(_menuPages, 0, levelDepth, null, children);
    }

    private IList<PageNavigator> DetermineChildren(string startingPoint, int? startLevel, List<int> pageList)
    {
        IList<Page> childPages = new List<Page>();
        IList<PageNavigator> childNavigators = new List<PageNavigator>();

        if (startingPoint != null)
        {
            if (startingPoint == "*")
            {
                childPages = _menuPages.Where(p => p.Level == _levelSkip).ToList();
            }
            else if (int.TryParse(startingPoint, out var pageId))
            {
                try
                {
                    Page page;
                    if (_levelSkip == 0)
                    {
                        page = _menuPages.Single(p => p.PageId == pageId);
                    }
                    else
                    {
                        page = _menuPages.Single(p => p.PageId == pageId);

                        var targetLevel = page.Level + _levelSkip;

                        childPages = _menuPages.Where(p => p.Level == targetLevel).ToList();
                    }

                    childPages.Add(page);
                }
                catch
                {
                    throw new ArgumentException("The parameter StartingPoint was given an invalid PageId:" + pageId);
                }
            }
            else
            {
                throw new ArgumentException("The parameter StartingPoint was given an invalid input" + startingPoint);
            }
        }

        if (startLevel != null)
        {
            childPages = _menuPages.Where(p => p.Level == startLevel).ToList();
        }

        if (pageList != null)
        {
            foreach (var pageId in pageList)
            {
                try
                {
                    childPages.Add(_menuPages.Single(p => p.PageId == pageId));
                }
                catch
                {
                    throw new ArgumentException("The parameter PageList was given an invalid PageId:" + pageId);
                }
            }
        }

        foreach (var childPage in childPages)
        {
            childNavigators.Add(new PageNavigator(_menuPages, 1, _levelDepth, childPage));
        }

        return _display ? childNavigators : new List<PageNavigator>();
    }
}