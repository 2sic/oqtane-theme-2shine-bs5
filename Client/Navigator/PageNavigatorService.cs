using Oqtane.Models;
using System.Collections.Generic;
using Oqtane.Services;
using System.Threading.Tasks;
using System.Linq;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Navigator
{
    public class PageNavigatorService
    {
        protected IPageService PageService { get; set; }
        
        public PageNavigatorService(IPageService pageService)
        {
            PageService = pageService;
        }

        private async Task<Page> DetermineStartPage(string StartingPoint, IEnumerable<Page> menuPages)
        {
            if (StartingPoint == null || StartingPoint == "*")
            {
                return null;
            }
            else if(int.TryParse(StartingPoint, out int pageId))
            {
                try
                {
                    var page = menuPages.SingleOrDefault(p => p.PageId == pageId);
                    //var page = await PageService.GetPageAsync(id);

                    return page;
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

        public async Task<PageNavigator> Start(IEnumerable<Page> menuPages, int level, string startingPoint)
        {
            if (_start != null) return _start;
            var startPage = await DetermineStartPage(startingPoint, menuPages);
            return new PageNavigator(menuPages, level, startPage, true);
        }
        private PageNavigator _start;
    }
}
