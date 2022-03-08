using Oqtane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Classes
{
    public class PageNavigatorFactory
    {
        public readonly IEnumerable<Page> MenuPages;
        public readonly int Levels;
        public readonly Page CurrentPage;

        public PageNavigatorFactory(IEnumerable<Page> menuPages, int level, Page currentPage)
        {
            MenuPages = menuPages;
            CurrentPage = currentPage;
            Levels = level;
        }

        public PageNavigator Start(IEnumerable<Page> menuPages, int level, Page currentPage)
        {
            return _start ??= new PageNavigator(MenuPages, Levels, null);
        }
        private PageNavigator _start;


        //public IEnumerable<PageNavigator> PageNav()
        //{
        //    if (CurrentPage == null)
        //    {
        //        IEnumerable<Page> rootpages = MenuPages
        //            .Where(pg => pg.Level == 0)
        //            .OrderBy(pg => pg.Order)
        //            .AsEnumerable();

        //        return rootpages.Select(rp => new PageNavigator(MenuPages, Levels, rp));

        //        //return new PageNavigator(null, MenuPages, Levels);

        //        //return new PageNavigator(MenuPages, Levels, CurrentPage);
        //    }
        //    else if (MenuPages == null || Levels == 0)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return new[] { new PageNavigator(MenuPages, Levels, CurrentPage) };
        //    }
        //}
    }
}
