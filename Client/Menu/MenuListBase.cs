using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Oqtane.UI;
using ToSic.Oqt.Themes.ToShineBs5.Client.Services;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu;

public abstract class MenuListBase: Oqtane.Themes.Controls.MenuBase
{
    [Parameter]
    [Required]
    public MenuBranch MenuBranch { get; set; }

    public string GetUrl() => GetUrl(MenuBranch.Page);

    protected abstract MenuCss MenuCss { get; }


    protected static string ToClasses(IEnumerable<string> original) => string.Join(" ", original);
    

}