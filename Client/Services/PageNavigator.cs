using Microsoft.AspNetCore.Components;
using Oqtane.Models;
using Oqtane.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Classes
{
    public class PageNavigator
    {
        public IEnumerable<Page> pages;

        public IEnumerable<Page> subpages;

        //public IEnumerable<Page> levelZeroPages;

        public Page PageNavigatorPage;
        public PageNavigator(Page pageNavPage, IEnumerable<Page> Pages)
        {
            pages = Pages;
            PageNavigatorPage = pageNavPage;
        }

        public IEnumerable<PageNavigator> Children
        {
            get
            {
                if(PageNavigatorPage.ParentId != null)
                {
                    subpages = pages
                        .Where(pg => pg.ParentId == PageNavigatorPage.PageId)
                        .OrderBy(pg => pg.Order)
                        .AsEnumerable();
                }
                else
                {
                    subpages = pages
                        .Where(pg => pg.Level == 0)
                        .OrderBy(pg => pg.Order)
                        .AsEnumerable();
                }
                return subpages.Select(sp => new PageNavigator(sp, subpages));
            }
        }
    }
}
