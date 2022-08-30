using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Controls.Menu;

public abstract class ToShineMenuBase: Oqtane.Themes.Controls.MenuBase
{
    [Parameter]
    [Required]
    public MenuBranch MenuBranch { get; set; }

    public string GetUrl(MenuBranch branch) => base.GetUrl(branch.Page);

}