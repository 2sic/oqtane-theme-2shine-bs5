using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Oqtane.Shared;
using ToSic.Oqt.Themes.ToShineBs5.Client.Classes;

namespace ToSic.Oqt.Themes.ToShineBs5.Client
{
    public class DemoStartup : Oqtane.Services.IClientStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<IPageNavigator, PageNavigator>();
        }
    }
}
