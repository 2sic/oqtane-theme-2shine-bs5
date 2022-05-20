using Microsoft.Extensions.DependencyInjection;
using ToSic.Oqt.Themes.ToSicStatus.Client.Nav;

namespace ToSic.Oqt.Themes.ToSicStatus.Client;

public class ServiceRegister : Oqtane.Services.IClientStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<PageNavigatorService>();
    }
}
