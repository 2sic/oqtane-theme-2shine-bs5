using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using ToSic.Oqt.Themes.ToShineBs5.Client.Services;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu;

public abstract class ToShineMenuBase: Oqtane.Themes.Controls.MenuBase
{
    [Parameter]
    [Required]
    public MenuBranch MenuBranch { get; set; }

    public string GetUrl(MenuBranch branch) => base.GetUrl(branch.Page);

}