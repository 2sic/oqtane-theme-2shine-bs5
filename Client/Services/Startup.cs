using Microsoft.Extensions.DependencyInjection;
using ToSic.Oqt.Themes.ToShineBs5.Client.ThemeSettings;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services;

public class Startup : Oqtane.Services.IClientStartup
{
    /// <summary>
    /// Register Services
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        // All these Settings etc. should be scoped, so they don't have to reload for each click
        services.AddScoped(typeof(SettingsFromJsonService<>));
        services.AddScoped(typeof(ThemeSettingsService<>));
        services.AddScoped(typeof(LanguageService<>));

        services.AddTransient(typeof(MenuTreeService<>));
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
