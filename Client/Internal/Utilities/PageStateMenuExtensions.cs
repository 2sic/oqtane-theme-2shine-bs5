﻿using Oqtane.Models;
using Oqtane.UI;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Internal.Utilities;

public static class PageStateMenuExtensions
{
    public static Page GetHomePage(this PageState pageState) => pageState.Pages.Find(p => p.Path == "");

    public static IEnumerable<Page> GetBreadcrumb(this PageState pageState)
        => GetBreadCrumbPages(pageState).Reverse().ToList();



    private static IEnumerable<Page> GetBreadCrumbPages(PageState pageState)
    {
        var page = pageState.Page;
        do
        {
            yield return page;
            page = pageState.Pages.FirstOrDefault(p => p.PageId == page?.ParentId);

        } while (page != null);
    }
}