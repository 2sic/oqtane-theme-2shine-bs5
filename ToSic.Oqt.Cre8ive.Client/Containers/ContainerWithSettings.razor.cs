using Microsoft.AspNetCore.Components;
using ToSic.Oqt.Cre8ive.Client.Controls;

namespace ToSic.Oqt.Cre8ive.Client.Containers;

public class ContainerWithSettings: Oqtane.Themes.ContainerBase, IControlWithSettings
{
    [CascadingParameter] public CurrentSettings Settings { get; set; }

    //[Inject] protected ContainerCssService ContainerCss { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    protected void CloseModal() => NavigationManager.NavigateTo(NavigateUrl());

    //protected override async Task OnParametersSetAsync()
    //{
    //    await base.OnParametersSetAsync();
    //    ContainerCss.InitSettings(Settings);
    //}

    public string? Classes(string tag) => Settings.ContainerDesign.Classes(ModuleState, tag).EmptyAsNull(); // ContainerCss.Classes(ModuleState).EmptyAsNull();
}