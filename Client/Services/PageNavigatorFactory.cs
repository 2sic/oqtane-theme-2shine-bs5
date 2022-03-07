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
        public IEnumerable<Page> MenuPages;
        int Levels;
        public Page? CurrentPage;

        public PageNavigatorFactory(IEnumerable<Page> _MenuPages, int _Level, Page? _CurrentPage)
        {
            MenuPages = _MenuPages;
            CurrentPage = _CurrentPage;
            Levels = _Level;
        }
        public PageNavigator PageNavigator
        {
            get
            {
                if(CurrentPage == null)
                {

                    return new PageNavigator(null, MenuPages, Levels);
                }
                else if(MenuPages == null || Levels == 0)
                {
                    return null;
                }
                else
                {
                    return new PageNavigator(CurrentPage, MenuPages, Levels);

                    //return PageNavigator PageNav () => new PageNavigator();
                }
            }
        }

        //protected PageNavigator PageNav()
        //{
        //    return new PageNavigator(CurrentPage, ParentPage);
        //}
    }
}
