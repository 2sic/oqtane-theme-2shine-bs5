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

        services.AddSingleton<ThemeSettings.ThemeSettingsService>();

        // Special services for the page
        //services.AddTransient<PageCssService>();
        services.AddTransient<ThemeJsService>();

        // Logic parts for Controls
        services.AddTransient<PageEditService>();


        // Defaults-Service
        services.AddSingleton<Defaults>();
    }
}
