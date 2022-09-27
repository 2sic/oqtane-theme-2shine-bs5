using Microsoft.Extensions.DependencyInjection;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services;

public class Startup : Oqtane.Services.IClientStartup
{
    /// <summary>
    /// Register Services
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        // TODO: MOVE this registration to Cre8Magic as soon as we can move the scripts
        services.AddTransient<IMagicThemeJsService, MagicThemeJsService>();
    }
}
