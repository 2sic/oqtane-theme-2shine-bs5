using System.Collections.Generic;
using System.Linq;
using ToSic.Oqt.Themes.ToShineBs5.Client.Services;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu;

public partial class NavItemSidebar
{
    protected override MenuCss MenuCss { get; } = new(ThemeCss.SidebarCssConfig);
}
