using System.Collections.Generic;
using System.Linq;

namespace ToSic.Oqt.Themes.ToSicStatus.Client.Menu;

public partial class NavItemMobile : NavItem
{
    private IList<string> MobileLiClasses()
    {
        var cssClasses = new List<string>
        {
            "position-relative"
        };
        return cssClasses;
    }
    private IList<string> MobileAClasses()
    {
        var linkCssClasses = new List<string>
        {
            "nav-link"
        };
        return linkCssClasses;
    }

    private string LiClasses() => ToClasses(CommonLiClasses().Concat(MobileLiClasses()));
    private string AClasses() => ToClasses(CommonAClasses().Concat(MobileAClasses()));
}