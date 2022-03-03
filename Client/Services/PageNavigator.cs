using Microsoft.AspNetCore.Components;
using Oqtane.Models;
using Oqtane.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services
{
    public class PageNavigator : IPageNavigator
    {
        public IPageService PageService;
        public async Task<IEnumerable<Page>> Test()
        {
            return await PageService.GetPagesAsync(1);
        }


        public string PageName = null;
        
        public PageNavigator(IPageService service)
        {
            PageService = service;
        }
    };
}
