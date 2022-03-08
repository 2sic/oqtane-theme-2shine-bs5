using Oqtane.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Classes
{
    public class PageNavigator
    {
        public IEnumerable<Page> Pages;

        public Page CurrentPage = null;

        private int Levels;

        //public IEnumerable<Page> Subpages;
        public PageNavigator(IEnumerable<Page> _Pages, int _Levels, Page _CurrentPage)
        {
            CurrentPage = _CurrentPage;
            Pages = _Pages;
            Levels = _Levels;
        }

        public bool HasChildren => Children.Any();

        public IList<PageNavigator> Children => _children ??= GetChildren().ToList();
        private IList<PageNavigator> _children;

        private IEnumerable<PageNavigator> GetChildren()
        {
            if (CurrentPage == null)
            {
                IEnumerable<Page> rootpages = Pages
                    .Where(pg => pg.Level == 0)
                    .OrderBy(pg => pg.Order)
                    .AsEnumerable();

                return rootpages.Select(rp => new PageNavigator(Pages, Levels, rp));
            }
            if (Levels > 0 && CurrentPage != null)
            {
                var Subpages = Pages
                    .Where(p => p.ParentId == CurrentPage.PageId)
                    .OrderBy(p => p.Order)
                    .AsEnumerable();

                Levels--;

                return Pages.Select(p => new PageNavigator(Pages, Levels, p));
            }
            else
            {
                //Subpages = null;
                return null;
            }
        }

    }
}
