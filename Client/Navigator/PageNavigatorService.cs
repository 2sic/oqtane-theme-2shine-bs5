using Oqtane.Models;
using System.Collections.Generic;
using Oqtane.Services;
using System.Threading.Tasks;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Navigator
{
    public class PageNavigatorService
    {
        protected IPageService PageService { get; set; }

        private IEnumerable<Page> MenuPages;
        private int Levels;
        private string StartingPoint;
        
        public PageNavigatorService(IPageService pageService)
        {
            PageService = pageService;
        }

        public PageNavigatorService Init(IEnumerable<Page> menuPages, int? level, string startingPoint)
        {
            MenuPages = menuPages;
            Levels = (int)level;
            StartingPoint = startingPoint;
            return this;
        }

        private async Task<Page> DetermineStartPage()
        {
            if (StartingPoint == null || StartingPoint == "*")
            {
                return null;
            }
            else if(int.TryParse(StartingPoint, out int pageId))
            {
                try
                {
                    Page currentPage;

                    int id =pageId;
                    currentPage = await PageService.GetPageAsync(id);

                    return currentPage;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task<PageNavigator> Start()
        {
            if (_start != null) return _start;
            var startPage = await DetermineStartPage();
            return new PageNavigator(MenuPages, Levels, startPage);
        }
        private PageNavigator _start;
    }
}
