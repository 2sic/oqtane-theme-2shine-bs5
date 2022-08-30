using Oqtane.Models;
using Oqtane.UI;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Internal.Utilities;

public static class PageStateMenuExtensions
{
    public static Page GetHomePage(this PageState pageState) => pageState.Pages.Find(p => p.Path == "");

    public static List<Page> Breadcrumb(this PageState pageState, Page page = null)
        => GetAncestors(pageState, page).Reverse().ToList();

    public static List<Page> Ancestors(this PageState pageState, Page page = null)
        => GetAncestors(pageState, page).ToList();

    private static IEnumerable<Page> GetAncestors(PageState pageState, Page page = null)
    {
        //page ??= pageState.Page;
        return GetAncestors(pageState.Pages, page ?? pageState.Page);

        //do
        //{
        //    yield return page;
        //    page = pageState.Pages.FirstOrDefault(p => p.PageId == page?.ParentId);

        //} while (page != null);
    }
    internal static IEnumerable<Page> GetAncestors(this List<Page> pages, Page page)
    {
        // page ??= pageState.Page;
        do
        {
            yield return page;
            page = pages.FirstOrDefault(p => p.PageId == page?.ParentId);

        } while (page != null);
    }
}