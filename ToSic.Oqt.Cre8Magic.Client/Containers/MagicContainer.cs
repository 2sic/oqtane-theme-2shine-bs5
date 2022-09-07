using Microsoft.AspNetCore.Components;
using ToSic.Oqt.Cre8Magic.Client.Controls;

namespace ToSic.Oqt.Cre8Magic.Client.Containers;

public class MagicContainer: Oqtane.Themes.ContainerBase, IMagicControlWithSettings
{
    [CascadingParameter] public MagicSettings Settings { get; set; }

    [Inject] public NavigationManager? NavigationManager { get; set; }

    protected void CloseModal() => NavigationManager?.NavigateTo(NavigateUrl());

    public string? Classes(string tag) => Settings.ContainerDesign.Classes(ModuleState, tag).EmptyAsNull();
}