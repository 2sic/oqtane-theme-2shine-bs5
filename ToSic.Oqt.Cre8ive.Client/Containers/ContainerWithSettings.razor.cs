using Microsoft.AspNetCore.Components;
using ToSic.Oqt.Cre8ive.Client.Controls;

namespace ToSic.Oqt.Cre8ive.Client.Containers;

public class ContainerWithSettings: Oqtane.Themes.ContainerBase, IControlWithSettings
{
    [CascadingParameter] public CurrentSettings Settings { get; set; }

    [Inject] protected ContainerCssService ContainerCss { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
        ContainerCss.InitSettings(Settings);
    }
}