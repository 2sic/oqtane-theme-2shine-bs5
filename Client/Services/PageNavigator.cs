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
        public IEnumerable<Page> Pages;

        public Page CurrentPage;

        private int Levels;

        public IEnumerable<Page>? Subpages;
        public PageNavigator(Page _CurrentPage, IEnumerable<Page> _Pages, int _Levels)
        {
            CurrentPage = _CurrentPage;
            Pages = _Pages;
            Levels = _Levels;
        }

        public IEnumerable<PageNavigator> Children
        {
            get
            {
                if(Levels > 0)
                {
                    Subpages = Pages
                        .Where(p => p.ParentId == CurrentPage.PageId)
                        .OrderBy(p => p.Order)
                        .AsEnumerable();

                    Levels--;

                    return Pages.Select(p => new PageNavigator(p, Pages, Levels));
                }
                else
                {
                    Subpages = null;
                }

                //if(parentPage == null)
                //{
                //    rootpages = pages
                //        .Where(pg => pg.Level == 0)
                //        .OrderBy(pg => pg.Order)
                //        .AsEnumerable();

                //    return rootpages.Select(rp => new PageNavigator(pages.Where(pg => pg.ParentId == rp.PageId), rp));
                //} 
                //else
                //{
                //    rootpages = pages; 
                //    return rootpages.Select(rp => new PageNavigator(pages.Where(pg => pg.ParentId == rp.PageId), rp));
                //}
            }
        }
    }
}
