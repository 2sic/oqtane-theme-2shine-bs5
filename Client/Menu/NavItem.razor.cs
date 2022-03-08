using Microsoft.AspNetCore.Components;
using Oqtane.Themes.Controls;
using System.Collections.Generic;
using ToSic.Oqt.Themes.ToShineBs5.Client.Navigator;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu;

public partial class NavItem : MenuBase
{
    [Parameter()]
    public PageNavigator PageNavigator { get; set; }

    public string liCLasses()
    {
        var cssClasses = new List<string>();
        cssClasses.Add("nav-item");
        cssClasses.Add("nav-" + PageNavigator.CurrentPage.PageId);

        if(PageNavigator.CurrentPage.Order == 1)
        { 
            cssClasses.Add("first"); 
        }

        //if (PageNavigator.CurrentPage.Order == length)
        //{
        //    cssClasses.Add("last");
        //}

        if (PageNavigator.CurrentPage.HasChildren == true) 
        { 
            cssClasses.Add("has-child dropdown"); 
        }

        //Use ? : instead of if, else
        if (this.PageState.Page.PageId == PageNavigator.CurrentPage.PageId) 
        { 
            cssClasses.Add("active"); 
        } 
        else 
        { 
            cssClasses.Add("inactive"); 
        }
        
        if (PageNavigator.CurrentPage.IsClickable == false) 
        { 
            cssClasses.Add("disabled"); 
        }

        var classString = string.Join(" ", cssClasses);
        return classString; 
    }

    public string aClasses()
    {
        var linkCssClasses = new List<string>();
        if(PageNavigator.CurrentPage.HasChildren && PageNavigator.CurrentPage.Level == 0)
        { 
            linkCssClasses.Add("dropdown-toggle"); 
        }

        //Use ? : instead of if, else
        if(PageNavigator.CurrentPage.Level != 0)
        { 
            linkCssClasses.Add("dropdown-item"); 
        } 
        else 
        { 
            linkCssClasses.Add("nav-link"); 
        }

        var linkClassString = string.Join(" ", linkCssClasses);
        
        return linkClassString;
    }
}
