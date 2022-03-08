using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Components;

using Oqtane.Models;
using Oqtane.UI;
using ToSic.Oqt.Themes.ToShineBs5.Client.Classes;

namespace Oqtane.Themes.Controls
{
    public abstract class MenuItemsBase : MenuBase
    {
        [Parameter()]
        public Page ParentPage { get; set; }

        [Parameter()]
        public IEnumerable<Page> Pages { get; set; }

        protected IEnumerable<Page> ToShineGetPages()
        {
            return Pages
                .Where(e => e.ParentId == ParentPage?.PageId)
                .OrderBy(e => e.Order)
                .AsEnumerable();
        }
        protected int CountPages()
        {
            int pageCount = ToShineGetPages().Count<Page>();
            return pageCount;
        }
        protected IEnumerable<Page> ToShineGetChildrenOfPage(int parentId)
        {
            return Pages
                .Where(Pages => Pages.ParentId == parentId)
                .OrderBy(Pages => Pages.Order)
                .AsEnumerable();
        }
        protected IEnumerable<Page> ToShineGetRootPages()
        {
            return Pages
                .Where(e => e.Level == 0)
                .OrderBy(e => e.Order)
                .AsEnumerable();
        }

        public int Levels = 10;
        protected PageNavigator Start => PageNavFactory().Start(MenuPages, Levels, ParentPage);

        protected PageNavigatorFactory PageNavFactory()
        {
            Page CurrentPage = ParentPage;
            int Levels = 10;

            return new PageNavigatorFactory(MenuPages, Levels, CurrentPage);
        }
    }
}