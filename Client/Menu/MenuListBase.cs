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

    public IList<string> CommonLiClasses(MenuBranch branch)
    {
        var commonClasses = new List<string>
        {
            "nav-item",
            "nav-" + branch.Page.PageId
        };

        if (branch.Page.Order == 1)
            commonClasses.Add("first");

        //if (PageNavigator.CurrentPage.Order == length)
        //    commonClasses.Add("last");

        commonClasses.Add(branch.IsActive ? "active" : "inactive");

        if (branch.HasChildren)
            commonClasses.Add("has-child");

        if (branch.Page.IsClickable == false)
            commonClasses.Add("disabled");

        return commonClasses;
    }

    //public IList<string> CommonAClasses()
    //{
    //    var cssClasses = new List<string>();
    //    if (MenuBranch.IsActive)// .Page.PageId == PageState.Page.PageId)
    //        cssClasses.Add("active");
    //    return cssClasses;
    //}

}