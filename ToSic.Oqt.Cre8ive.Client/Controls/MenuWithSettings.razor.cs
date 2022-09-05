using Microsoft.AspNetCore.Components;

namespace ToSic.Oqt.Cre8ive.Client.Controls;

public class MenuWithSettings: Oqtane.Themes.Controls.MenuBase
{
    [CascadingParameter] public CurrentSettings Settings { get; set; }

}