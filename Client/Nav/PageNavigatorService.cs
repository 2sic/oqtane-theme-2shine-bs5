using Oqtane.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Nav;

public class PageNavigatorService
{
    private IEnumerable<Page> MenuPages;

    private int LevelDepth;

    public PageNavigator Start(IEnumerable<Page> menupages, int leveldepth, string startingpoint = null, int? startlevel = null, List<int> pagelist = null)
    {
        MenuPages = menupages;
        LevelDepth = leveldepth;

        var Children = DetermineChildren(startingpoint, startlevel, pagelist);
        return new PageNavigator(MenuPages, 0, leveldepth, null, Children);
    }

    private IList<PageNavigator> DetermineChildren(string startingpoint, int? startlevel, List<int> pagelist)
    {
        IList<Page> childPages = new List<Page>();
        IList<PageNavigator> childNavigators = new List<PageNavigator>();

        if(startingpoint != null)
        {
            if(startingpoint == "*")
            {
                childPages = MenuPages.Where(p => p.Level == 0).ToList();
            }
            else if (int.TryParse(startingpoint, out int pageId))
            {
                try
                {
                    var page = MenuPages.Single(p => p.PageId == pageId);

                    childPages.Add(page);
                }
                catch
                {
                    childPages = null;
                }
            }
            else
            {
                childPages = null;
            }
        }

        if(startlevel != null)
        {
            try
            {
                childPages = MenuPages.Where(p => p.Level == startlevel).ToList();
            }
            catch
            {
                childPages = null;
            }
        }

        if(pagelist != null)
        {
            foreach (var pageId in pagelist)
            {
                try
                {
                    childPages.Add(MenuPages.Single(p => p.PageId == pageId));
                }
                catch
                {
                    continue;
                }
            }
        }
        
        foreach (var childPage in childPages)
        {
            childNavigators.Add(new PageNavigator(MenuPages, 1, LevelDepth, childPage));
        }

        return childNavigators;
    }
}