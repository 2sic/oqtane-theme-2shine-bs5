using Microsoft.AspNetCore.Components;
using Oqtane.Themes.Controls;
using System.Collections.Generic;
using ToSic.Oqt.Themes.ToShineBs5.Client.Navigator;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu.Main
{
    public partial class NavItem : MenuBase
    {
        [Parameter()]
        public PageNavigator PageNavigator { get; set; }

        public string LinkHref()
        {
            string href = "";

            if (PageNavigator.CurrentPage.IsClickable)
            {
                href = PageNavigator.CurrentPage.Path;
            }
            else
            {
                href = "javascript:void(0)";
            }

            return href;
        }

        public string CommonLiClasses()
        {
            var commonClasses = new List<string>();

            commonClasses.Add("nav-item");
            commonClasses.Add("nav-" + PageNavigator.CurrentPage.PageId);

            if (PageNavigator.CurrentPage.Order == 1)
            {
                commonClasses.Add("first");
            }

            //if (PageNavigator.CurrentPage.Order == length)
            //{
            //    commonClasses.Add("last");
            //}

            if (PageState.Page.PageId == PageNavigator.CurrentPage.PageId)
            {
                commonClasses.Add("active");
            }
            else
            {
                commonClasses.Add("inactive");
            }

            if (PageNavigator.HasChildren)
            {
                commonClasses.Add("has-child");
            }

            if (PageNavigator.CurrentPage.IsClickable == false)
            {
                commonClasses.Add("disabled");
            }

            var commonClassesString = string.Join(" ", commonClasses);
            return commonClassesString;
        }
        public string CommonLinkClasses()
        {
            var commonClasses = new List<string>();

            if (PageNavigator.CurrentPage.PageId == PageState.Page.PageId)
            {
                commonClasses.Add("active");
            }

            var commonClassesString = string.Join(" ", commonClasses);
            return commonClassesString;
        }
        private string MainLiCLasses()
        {
            var cssClasses = new List<string>();

            if (PageNavigator.HasChildren)
            {
                cssClasses.Add("dropdown");
            }

            var classString = string.Join(" ", cssClasses);
            return classString;
        }
        private string MainLinkClasses()
        {
            var linkCssClasses = new List<string>();
            if (PageNavigator.CurrentPage.HasChildren && PageNavigator.CurrentPage.Level < 1)
            {
                linkCssClasses.Add("dropdown-toggle");
            }

            if (PageNavigator.CurrentPage.Level != 0)
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

        private string LiClasses()
        {
            return CommonLiClasses() + " " + MainLiCLasses();
        }
        private string LinkClasses()
        {
            return CommonLinkClasses() + " " + MainLinkClasses();
        }
    }
}