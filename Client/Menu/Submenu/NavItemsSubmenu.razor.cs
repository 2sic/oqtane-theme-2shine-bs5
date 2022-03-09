using Microsoft.AspNetCore.Components;
using Oqtane.Themes.Controls;
using ToSic.Oqt.Themes.ToShineBs5.Client.Navigator;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu.Submenu;

public partial class NavItemsSubmenu : MenuBase
{
    [Parameter()]
    public PageNavigator PageNavigator { get; set; }
}