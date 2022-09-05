using Microsoft.AspNetCore.Components;
using Oqtane.Themes;

namespace ToSic.Oqt.Cre8ive.Client.Controls;

public abstract class ControlWithSettings: ThemeControlBase, IControlWithSettings
{
    [CascadingParameter] public CurrentSettings Settings { get; set; }

}