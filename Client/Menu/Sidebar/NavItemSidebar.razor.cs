using System.Collections.Generic;
using ToSic.Oqt.Themes.ToShineBs5.Client.Navigator;
using ToSic.Oqt.Themes.ToShineBs5.Client.Menu.Main;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu.Sidebar
{
    public partial class NavItemSidebar : NavItem
    {
        private string SubLiClasses()
        {
            var cssClasses = new List<string>();

            cssClasses.Add("position-relative");


            var classString = string.Join(" ", cssClasses);
            return classString;
        }
        private string SubLinkClasses()
        {
            var linkCssClasses = new List<string>();

            linkCssClasses.Add("nav-link");

            var linkClassString = string.Join(" ", linkCssClasses);
            return linkClassString;
        }

        private string LiClasses()
        {
            return CommonLiClasses() + " " + SubLiClasses();
        }
        private string LinkClasses()
        {
            return CommonLinkClasses() + " " + SubLinkClasses();
        }
    }
}