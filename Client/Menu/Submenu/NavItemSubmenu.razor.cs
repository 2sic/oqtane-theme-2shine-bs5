using Microsoft.AspNetCore.Components;
using Oqtane.Themes.Controls;
using System.Collections.Generic;
using ToSic.Oqt.Themes.ToShineBs5.Client.Navigator;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu.Submenu;

public partial class NavItemSubmenu : MenuBase
{
    [Parameter()]
    public PageNavigator PageNavigator { get; set; }

    public string liCLasses()
    {
        var cssClasses = new List<string>();
        cssClasses.Add("nav-item");
        cssClasses.Add("nav-" + PageNavigator.CurrentPage.PageId);
        cssClasses.Add("position-relative");

        if (PageNavigator.CurrentPage.Order == 1)
        {
            cssClasses.Add("first");
        }

        //if (PageNavigator.CurrentPage.Order == length)
        //{
        //    cssClasses.Add("last");
        //}

        if (PageNavigator.HasChildren)
        {
            cssClasses.Add("has-child");
        }

        //Use ? : instead of if, else
        if (PageState.Page.PageId == PageNavigator.CurrentPage.PageId)
        {
            cssClasses.Add("active");
        }
        else
        {
            cssClasses.Add("inactive");
        }

        if (PageNavigator.CurrentPage.IsClickable == false)
        {
            cssClasses.Add("disabled");
        }

        var classString = string.Join(" ", cssClasses);
        return classString;
    }

    public string aClasses()
    {
        var linkCssClasses = new List<string>();
        linkCssClasses.Add("nav-link");

        if (PageNavigator.CurrentPage.PageId == PageState.Page.PageId)
        {
            linkCssClasses.Add("active");
        }

        var linkClassString = string.Join(" ", linkCssClasses);

        return linkClassString;
    }

    public string aDataBsToggle()
    {
        string dataBsToggle = "";
        if (PageNavigator.CurrentPage.HasChildren && PageNavigator.CurrentPage.IsClickable)
        {
            dataBsToggle = "dropdown";
        }
        return dataBsToggle;
    }

    public string aHref()
    {
        string href = "";
        if (PageNavigator.CurrentPage.IsClickable)
        {
            href = PageNavigator.CurrentPage.Path;
        }
        else
        {
            href = "javascript:void(0)";
        }
        return href;
    }

    public string spanAttributes()
    {
        string attributes = "";
        if (PageNavigator.HasChildren)
        {
            attributes = "data-bs-toggle=dropdown data-bs-target=.dropdown-" + PageNavigator.CurrentPage.PageId;
        }
        return attributes;
    }
}
