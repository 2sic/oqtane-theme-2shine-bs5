using Oqtane.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Nav;

public class PageNavigatorService
{
    private IEnumerable<Page> MenuPages;

    private int LevelDepth;

    private int LevelSkip;

    private bool Display;

    public PageNavigator Start(IEnumerable<Page> menupages, int leveldepth, bool display, int levelskip, string startingpoint = null, int? startlevel = null, List<int> pagelist = null)
    {
        MenuPages = menupages;
        LevelDepth = leveldepth;
        LevelSkip = levelskip;
        Display = display;

        var Children = DetermineChildren(startingpoint, startlevel, pagelist);
        return new PageNavigator(MenuPages, 0, leveldepth, null, Children);
    }

    private IList<PageNavigator> DetermineChildren(string startingpoint, int? startlevel, List<int> pagelist)
    {
        IList<Page> childPages = new List<Page>();
        IList<PageNavigator> childNavigators = new List<PageNavigator>();

        if (startingpoint != null)
        {
            if (startingpoint == "*")
            {
                childPages = MenuPages.Where(p => p.Level == LevelSkip).ToList();
            }
            else if (int.TryParse(startingpoint, out int pageId))
            {
                try
                {
                    Page page;
                    if (LevelSkip == 0)
                    {
                        page = MenuPages.Single(p => p.PageId == pageId);
                    }
                    else
                    {
                        page = MenuPages.Single(p => p.PageId == pageId);

                        var targetLevel = page.Level + LevelSkip;

                        childPages = MenuPages.Where(p => p.Level == targetLevel).ToList();
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
                throw new ArgumentException("The parameter StartingPoint was given an invalid input" + startingpoint);
            }
        }

        if (startlevel != null)
        {
            childPages = MenuPages.Where(p => p.Level == startlevel).ToList();
        }

        if (pagelist != null)
        {
            foreach (var pageId in pagelist)
            {
                try
                {
                    childPages.Add(MenuPages.Single(p => p.PageId == pageId));
                }
                catch
                {
                    throw new ArgumentException("The parameter PageList was given an invalid PageId:" + pageId);
                }
            }
        }

        foreach (var childPage in childPages)
        {
            childNavigators.Add(new PageNavigator(MenuPages, 1, LevelDepth, childPage));
        }

        if (Display == true)
        {
            return childNavigators;
        }
        else
        {
            return new List<PageNavigator>();
        }
    }
}