using Microsoft.AspNetCore.Components;

namespace ToSic.Oqt.Cre8ive.Client.Menu;

/// <summary>
/// Base class for Razor menus
/// </summary>
/// <typeparam name="TPackageSettings"></typeparam>
public abstract class MenuRootBase<TPackageSettings> : Oqtane.Themes.Controls.MenuBase, IMenuConfig where TPackageSettings : ThemePackageSettingsBase, new()
{
    /// <inheritdoc />
    [Parameter] public string? Id { get; set; }
    /// <inheritdoc />
    [Parameter] public string? ConfigName { get; set; }
    /// <inheritdoc />
    [Parameter] public List<int>? PageList { get; set; }
    /// <inheritdoc />
    [Parameter] public bool? Children { get; set; }
    /// <inheritdoc />
    [Parameter] public int? Depth { get; set; }
    /// <inheritdoc />
    [Parameter] public bool Debug { get; set; }
    /// <inheritdoc />
    [Parameter] public bool? Display { get; set; } = true;
    /// <inheritdoc />
    [Parameter] public int? Level { get; set; }
    /// <inheritdoc />
    [Parameter] public string? Start { get; set; }
    /// <inheritdoc />
    [Parameter] public string? Design { get; set; }

    protected MenuTree? MenuTree { get; private set; }

    [Inject] protected MenuTreeService<TPackageSettings>? MenuTreeService { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
        MenuTree = MenuTreeService?.GetTree(new MenuConfig(this), PageState, MenuPages.ToList());
    }

}