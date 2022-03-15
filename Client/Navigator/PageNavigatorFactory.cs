using Oqtane.Models;
using System.Collections.Generic;
using Oqtane.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Navigator
{
    public class PageNavigatorFactory
    {
        [Inject]
        protected IPageService PageService { get; set; }

        private readonly IEnumerable<Page> MenuPages;
        private readonly int Levels;
        private readonly string StartingPoint;

        public PageNavigatorFactory(IEnumerable<Page> menuPages, int? level, string startingPoint)
        {
            MenuPages = menuPages;
            //CurrentPage = currentPage;
            Levels = (int)level;
            StartingPoint = startingPoint;
        }

        private async Task<Page> DetermineStartPage()
        {
            if (StartingPoint == null || StartingPoint == "*")
            {
                return null;
            }
            else if(int.TryParse(StartingPoint, out int pageId))
            {
                return await PageService.GetPageAsync(pageId);
            }
            else
            {
                return null;
            }
        }

        public async Task<PageNavigator> Start()
        {
            if (_start != null) return _start;
            var x = await DetermineStartPage();
            return new PageNavigator(MenuPages, Levels, x);
        }
        private PageNavigator _start;
    }
}
