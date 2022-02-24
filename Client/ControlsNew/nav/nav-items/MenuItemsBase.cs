using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Components;

using Oqtane.Models;
using Oqtane.UI;

namespace Oqtane.Themes.Controls
{
    public abstract class MenuItemsBase : MenuBase
    {
        [Parameter()]
        public Page ParentPage { get; set; }

        [Parameter()]
        public IEnumerable<Page> Pages { get; set; }

        protected IEnumerable<Page> GetChildPagesToShine()
        {
            return Pages
                .Where(e => e.ParentId == ParentPage?.PageId)
                .OrderBy(e => e.Order)
                .AsEnumerable();
        }
        protected int CountPages()
        {
            int pageCount = GetChildPagesToShine().Count<Page>();
            return pageCount;
        }
        protected IEnumerable<Page> GetChildrenOfPage(int parentId)
        {
            return Pages
                .Where(Pages => Pages.ParentId == parentId)
                .OrderBy(Pages => Pages.Order)
                .AsEnumerable();
        }
    }
}
