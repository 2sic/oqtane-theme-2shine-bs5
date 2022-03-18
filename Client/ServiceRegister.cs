using Microsoft.Extensions.DependencyInjection;
using ToSic.Oqt.Themes.ToShineBs5.Client.Nav;

namespace ToSic.Oqt.Themes.ToShineBs5.Client;

public class ServiceRegister : Oqtane.Services.IClientStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<PageNavigatorService>();
    }
}
