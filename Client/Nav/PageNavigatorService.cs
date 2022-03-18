using Oqtane.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Nav;

public class PageNavigatorService
{
    private static Page DetermineStartPage(string StartingPoint, IEnumerable<Page> menuPages)
    {
        if (StartingPoint == null || StartingPoint == "*")
        {
            return null;
        }
        else if (int.TryParse(StartingPoint, out int pageId))
        {
            try
            {
                var page = menuPages.SingleOrDefault(p => p.PageId == pageId);

                return page;
            }
            catch
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public PageNavigator Start(IEnumerable<Page> menuPages, int level, string startingPoint)
    {
        if (_start != null) return _start;
        var startPage = DetermineStartPage(startingPoint, menuPages);
        return new PageNavigator(menuPages, level, startPage, true);
    }
    private PageNavigator _start;
}
