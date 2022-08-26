using System.Collections.Generic;
using System.Linq;
using ToSic.Oqt.Themes.ToShineBs5.Client.Services;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu;

public partial class MenuItem // Oqtane.Themes.Controls.MenuBase
{
    //[Parameter]
    //[Required]
    //public MenuBranch MenuBranch { get; set; }

    // WIP
    protected override MenuCss MenuCss { get; } = new(new())
    {
        LinkCustom = branch =>
        {
            var cls = "";
            //var cssClasses = new List<string>();
            if (branch.HasChildren)
                cls += " dropdown-toggle";
            //cssClasses.Add("dropdown-toggle");

            cls += " " + (branch.MenuLevel == 1 ? "nav-link" : "dropdown-item");
            //cssClasses.Add(MenuBranch.MenuLevel == 1 ? "nav-link" : "dropdown-item");
            return cls;// cssClasses;
        }
    };

    //public string GetUrl() => GetUrl(MenuBranch.Page);
    //    //=> MenuBranch.Page.IsClickable
    //    //    ? MenuBranch.Page.Path
    //    //    : "javascript:void(0)";

    //protected static string ToClasses(IEnumerable<string> original) => string.Join(" ", original);

    //public IList<string> CommonLiClasses()
    //{
    //    var commonClasses = new List<string>
    //    {
    //        "nav-item",
    //        "nav-" + MenuBranch.Page.PageId
    //    };

    //    if (MenuBranch.Page.Order == 1)
    //        commonClasses.Add("first");

    //    //if (PageNavigator.CurrentPage.Order == length)
    //    //    commonClasses.Add("last");

    //    commonClasses.Add(PageState.Page.PageId == MenuBranch.Page.PageId ? "active" : "inactive");

    //    if (MenuBranch.HasChildren)
    //        commonClasses.Add("has-child");

    //    if (MenuBranch.Page.IsClickable == false)
    //        commonClasses.Add("disabled");

    //    return commonClasses;
    //}

    //public IList<string> CommonAClasses()
    //{
    //    var cssClasses = new List<string>();
    //    if (MenuBranch.IsActive)// .Page.PageId == PageState.Page.PageId)
    //        cssClasses.Add("active");
    //    return cssClasses;
    //}

    private IList<string> MainLiCLasses()
    {
        var cssClasses = new List<string>();
        if (MenuBranch.HasChildren)
            cssClasses.Add("dropdown");
        return cssClasses;
    }

    //private IList<string> MainAClasses()
    //{
    //    var cssClasses = new List<string>();
    //    if (MenuBranch.HasChildren)
    //        cssClasses.Add("dropdown-toggle");

    //    cssClasses.Add(MenuBranch.MenuLevel == 1 ? "nav-link" : "dropdown-item");
    //    return cssClasses;
    //}

    private string LiClasses() => ToClasses(CommonLiClasses().Concat(MainLiCLasses()));
    //private string AClasses() => ToClasses(CommonAClasses().Concat(MainAClasses()));
}