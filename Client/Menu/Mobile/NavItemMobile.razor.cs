using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using ToSic.Oqt.Themes.ToShineBs5.Client.Navigator;
using ToSic.Oqt.Themes.ToShineBs5.Client.Menu.Main;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu.Mobile;

public partial class NavItemMobile : NavItem
{
    private string MobileLiClasses()
    {
        var cssClasses = new List<string>();

        if (PageNavigator.HasChildren)
        {
            cssClasses.Add("dropdown");
        }

        var classString = string.Join(" ", cssClasses);
        return classString;
    }
    private string MobileLinkClasses()
    {
        var linkCssClasses = new List<string>();
        if (PageNavigator.CurrentPage.HasChildren && PageNavigator.CurrentPage.Level == 0)
        {
            linkCssClasses.Add("dropdown-item");
        }

        if (PageNavigator.CurrentPage.Level != 0)
        {
            linkCssClasses.Add("dropdown-item");
        }
        else
        {
            linkCssClasses.Add("nav-link");
        }

        var linkClassString = string.Join(" ", linkCssClasses);

        return linkClassString;
    }

    private string LiClasses()
    {
        return CommonLiClasses() + " " + MobileLiClasses();
    }
    private string LinkClasses()
    {
        return CommonLinkClasses() + " " + MobileLinkClasses();
    }
}