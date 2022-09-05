﻿using Microsoft.AspNetCore.Components;

namespace ToSic.Oqt.Cre8ive.Client.Controls.Menu;

/// <summary>
/// Base class for Razor menus
/// </summary>
public abstract class MenuRootBase: MenuWithSettings, IMenuConfig
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

    [Inject] protected MenuTreeService? MenuTreeService { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
        MenuTreeService!.InitSettings(Settings);
        MenuTree = MenuTreeService?.GetTree(new MenuConfig(this), PageState, MenuPages.ToList());
    }

}