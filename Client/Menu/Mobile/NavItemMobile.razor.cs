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

        cssClasses.Add("position-relative");

        var classString = string.Join(" ", cssClasses);
        return classString;
    }
    private string MobileLinkClasses()
    {
        var linkCssClasses = new List<string>();

        linkCssClasses.Add("nav-link");

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