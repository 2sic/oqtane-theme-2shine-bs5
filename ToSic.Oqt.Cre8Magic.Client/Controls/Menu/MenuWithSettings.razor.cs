using Microsoft.AspNetCore.Components;

namespace ToSic.Oqt.Cre8Magic.Client.Controls.Menu;

public class MenuWithSettings: Oqtane.Themes.Controls.MenuBase, IControlWithSettings
{
    [CascadingParameter] public CurrentSettings Settings { get; set; }

}