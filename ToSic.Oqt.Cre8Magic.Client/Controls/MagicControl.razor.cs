using Microsoft.AspNetCore.Components;
using Oqtane.Themes;

namespace ToSic.Oqt.Cre8Magic.Client.Controls;

public abstract class MagicControl: ThemeControlBase, IControlWithSettings
{
    [CascadingParameter] public CurrentSettings Settings { get; set; }
}