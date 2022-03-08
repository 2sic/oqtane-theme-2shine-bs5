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
        public IEnumerable<PageNavigator> Pages { get; set; }

        public int Levels { get; set; }

        protected PageNavigator Start => PageNavFactory().Start();

        protected PageNavigatorFactory PageNavFactory()
        {
            Page CurrentPage = ParentPage;
            int Levels = 10;

            return new PageNavigatorFactory(MenuPages, Levels, CurrentPage);
        }
    }
}
