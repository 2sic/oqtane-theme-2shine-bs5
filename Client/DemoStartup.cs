using Microsoft.Extensions.DependencyInjection;

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
