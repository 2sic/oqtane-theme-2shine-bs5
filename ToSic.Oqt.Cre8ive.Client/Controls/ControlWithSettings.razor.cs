using Microsoft.AspNetCore.Components;
using Oqtane.Themes;

namespace ToSic.Oqt.Cre8ive.Client.Controls;

public class ControlWithSettings: ThemeControlBase
{
    [CascadingParameter] public CurrentSettings Settings { get; set; }

}