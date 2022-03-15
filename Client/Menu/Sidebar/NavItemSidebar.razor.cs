using System.Collections.Generic;
using ToSic.Oqt.Themes.ToShineBs5.Client.Navigator;
using ToSic.Oqt.Themes.ToShineBs5.Client.Menu.Main;
using System.Linq;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu.Sidebar
{
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
}