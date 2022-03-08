using Oqtane.Models;
using System.Collections.Generic;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Navigator
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

        public PageNavigator Start()
        {
            return _start ??= new PageNavigator(MenuPages, Levels, null);
        }
        private PageNavigator _start;
    }
}
