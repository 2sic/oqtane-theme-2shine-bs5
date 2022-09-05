using Microsoft.AspNetCore.Components;

namespace ToSic.Oqt.Cre8ive.Client.Controls;

public class ContainerWithSettings: Oqtane.Themes.ContainerBase
{
    [CascadingParameter] public CurrentSettings Settings { get; set; }

    [Inject] protected ContainerCssService ContainerCss { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
        ContainerCss.InitSettings(Settings);
    }
}