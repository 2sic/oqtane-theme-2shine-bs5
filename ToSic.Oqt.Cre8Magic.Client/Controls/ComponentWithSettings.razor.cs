using Microsoft.AspNetCore.Components;

namespace ToSic.Oqt.Cre8Magic.Client.Controls;

public abstract class ComponentWithSettings: ComponentBase, IControlWithSettings
{
    [CascadingParameter] public CurrentSettings Settings { get; set; }
}