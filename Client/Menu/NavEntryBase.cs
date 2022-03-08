using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Oqtane.Models;
using Oqtane.Themes.Controls;
using ToSic.Oqt.Themes.ToShineBs5.Client.Navigator;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu
{
    public abstract class NavEntryBase : MenuBase
    {
        [Parameter()]
        public Page ParentPage { get; set; }

        [Parameter()]
        public IEnumerable<PageNavigator> PageNavigators { get; set; }

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
