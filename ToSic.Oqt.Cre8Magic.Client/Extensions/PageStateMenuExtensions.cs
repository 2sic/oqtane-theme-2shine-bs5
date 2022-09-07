using Oqtane.Models;
using Oqtane.UI;

namespace ToSic.Oqt.Cre8Magic.Client;

public static class PageStateMenuExtensions
{
    public static Page? GetHomePage(this PageState pageState) => pageState.Pages.Find(p => p.Path == "");

    public static List<Page> Breadcrumb(this PageState pageState, Page? page = null)
        => GetAncestors(pageState, page).Reverse().ToList();

    internal static List<Page> Breadcrumb(this List<Page> pages, Page page)
        => GetAncestors(pages, page).Reverse().ToList();

    internal static List<Page> Ancestors(this PageState pageState, Page? page = null)
        => GetAncestors(pageState, page).ToList();

    private static IEnumerable<Page> GetAncestors(PageState pageState, Page? page = null) 
        => GetAncestors(pageState.Pages, page ?? pageState.Page);

    internal static IEnumerable<Page> GetAncestors(this List<Page> pages, Page? page)
    {
        while (page != null)
        {
            yield return page;
            page = pages.FirstOrDefault(p => p.PageId == page.ParentId);
        }
    }
}