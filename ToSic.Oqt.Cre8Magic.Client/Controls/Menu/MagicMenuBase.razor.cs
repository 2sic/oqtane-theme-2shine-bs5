using Microsoft.AspNetCore.Components;

namespace ToSic.Oqt.Cre8Magic.Client.Controls.Menu;

public abstract class MagicMenuBase: Oqtane.Themes.Controls.MenuBase, IControlWithSettings
{
    [CascadingParameter] public CurrentSettings Settings { get; set; }

}