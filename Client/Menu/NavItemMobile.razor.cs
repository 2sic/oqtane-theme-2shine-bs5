using System.Collections.Generic;
using System.Linq;
using ToSic.Oqt.Themes.ToShineBs5.Client.Services;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu;

public partial class NavItemMobile
{
    protected override MenuCss MenuCss { get; } = new(ThemeCss.MobileCssConfig);

    private IList<string> MobileLiClasses()
    {
        var cssClasses = new List<string>
        {
            "position-relative"
        };
        return cssClasses;
    }
    //private IList<string> MobileAClasses()
    //{
    //    var linkCssClasses = new List<string>
    //    {
    //        "nav-link",
    //        "mobile-navigation-link"
    //    };
    //    return linkCssClasses;
    //}

    private string LiClasses() => ToClasses(CommonLiClasses().Concat(MobileLiClasses()));
    //private string AClasses() => ToClasses(CommonAClasses().Concat(MobileAClasses()));


}