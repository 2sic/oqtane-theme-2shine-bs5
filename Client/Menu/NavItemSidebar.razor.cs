using System.Collections.Generic;
using System.Linq;
using ToSic.Oqt.Themes.ToShineBs5.Client.Services;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu;

public partial class NavItemSidebar
{
    protected override MenuCss MenuCss { get; } = new(ThemeCss.SidebarCssConfig);

    private IList<string> SubLiClasses()
    {
        var cssClasses = new List<string>
        {
            "position-relative"
        };
        return cssClasses;
    }
    //private IList<string> SubAClasses()
    //{
    //    var cssClasses = new List<string>
    //    {
    //        "nav-link"
    //    };
    //    return cssClasses;
    //}

    private string LiClasses() => ToClasses(CommonLiClasses().Concat(SubLiClasses()));
    //private string AClasses() => ToClasses(CommonAClasses().Concat(SubAClasses()));
}
