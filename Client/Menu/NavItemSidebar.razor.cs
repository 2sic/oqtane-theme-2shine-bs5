using System.Collections.Generic;
using System.Linq;

namespace ToSic.Oqt.Themes.ToSicStatus.Client.Menu;

public partial class NavItemSidebar : NavItem
{
    private IList<string> SubLiClasses()
    {
        var cssClasses = new List<string>
        {
            "position-relative"
        };
        return cssClasses;
    }
    private IList<string> SubAClasses()
    {
        var cssClasses = new List<string>
        {
            "nav-link"
        };
        return cssClasses;
    }

    private string LiClasses() => ToClasses(CommonLiClasses().Concat(SubLiClasses()));
    private string AClasses() => ToClasses(CommonAClasses().Concat(SubAClasses()));
}
