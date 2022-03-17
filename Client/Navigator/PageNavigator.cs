using Oqtane.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Navigator
{
    public class PageNavigator
    {
        public IEnumerable<Page> Pages;

        public Page CurrentPage = null;

        private int Levels;

        public bool First;

        public PageNavigator(IEnumerable<Page> _Pages, int _Levels, Page _CurrentPage, bool first)
        {
            CurrentPage = _CurrentPage;
            Pages = _Pages;
            Levels = _Levels;
            First = first;
        }

        public bool HasChildren => Children.Any();

        public IList<PageNavigator> Children => _children ??= GetChildren().ToList();
        private IList<PageNavigator> _children;

        private IEnumerable<PageNavigator> GetChildren()
        {
            if (Levels > 0)
            {
                Levels--;
                IEnumerable<Page> childPages; 
                if(CurrentPage != null)
                {
                    childPages = Pages.Where(p => p.ParentId == CurrentPage.PageId);
                }
                else
                {
                    childPages = Pages.Where(p => p.ParentId == null);
                }

                return childPages.Select(p => new PageNavigator(Pages, Levels, p, false));
            }
            else
            {
                return new List<PageNavigator>();
            }
        }
    }
}
