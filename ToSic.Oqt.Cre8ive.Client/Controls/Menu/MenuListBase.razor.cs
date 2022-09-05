using Microsoft.AspNetCore.Components;

namespace ToSic.Oqt.Cre8ive.Client.Controls.Menu;

/// <summary>
/// Base class for any menu list
/// </summary>
public abstract class MenuListBase: Oqtane.Themes.Controls.MenuBase
{
#pragma warning disable CS8618
    [Parameter, EditorRequired] public MenuBranch MenuBranch { get; set; }
#pragma warning restore CS8618
    
    public string GetUrl(MenuBranch branch) => GetUrl(branch.Page);

}