using Microsoft.AspNetCore.Components;
using Oqtane.Themes.Controls;
using System.Collections.Generic;
using System.Linq;
using ToSic.Oqt.Themes.ToShineBs5.Client.Nav;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu;

public partial class NavItem : MenuBase
{
    [Parameter()]
    public PageNavigator PageNavigator { get; set; }

    public string LinkHref()
        => PageNavigator.CurrentPage.IsClickable
            ? PageNavigator.CurrentPage.Path
            : "javascript:void(0)";

    protected static string ToClasses(IEnumerable<string> original) => string.Join(" ", original);

    public IList<string> CommonLiClasses()
    {
        var commonClasses = new List<string>
        {
            "nav-item",
            "nav-" + PageNavigator.CurrentPage.PageId
        };

        if (PageNavigator.CurrentPage.Order == 1)
            commonClasses.Add("first");

        //if (PageNavigator.CurrentPage.Order == length)
        //    commonClasses.Add("last");

        if (PageState.Page.PageId == PageNavigator.CurrentPage.PageId)
            commonClasses.Add("active");
        else
            commonClasses.Add("inactive");

        if (PageNavigator.HasChildren)
            commonClasses.Add("has-child");

        if (PageNavigator.CurrentPage.IsClickable == false)
            commonClasses.Add("disabled");

        return commonClasses;
    }

    public IList<string> CommonAClasses()
    {
        var cssClasses = new List<string>();
        if (PageNavigator.CurrentPage.PageId == PageState.Page.PageId)
            cssClasses.Add("active");
        return cssClasses;
    }

    private IList<string> MainLiCLasses()
    {
        var cssClasses = new List<string>();
        if (PageNavigator.HasChildren)
            cssClasses.Add("dropdown");
        return cssClasses;
    }

    private IList<string> MainAClasses()
    {
        var cssClasses = new List<string>();
        if (PageNavigator.CurrentPage.HasChildren)
            cssClasses.Add("dropdown-toggle");

        if (PageNavigator.First == true)
            cssClasses.Add("nav-link");
        else
            cssClasses.Add("dropdown-item");

        return cssClasses;
    }

    private string LiClasses() => ToClasses(CommonLiClasses().Concat(MainLiCLasses()));
    private string AClasses() => ToClasses(CommonAClasses().Concat(MainAClasses()));
}