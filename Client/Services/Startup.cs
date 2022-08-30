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
        services.AddScoped<SettingsFromJsonService>();
        services.AddScoped<ThemeSettingsService>();
        services.AddTransient<MenuTreeService>();
        services.AddSingleton<ThemeSettings.ThemeSettingsService>();

        // Special services for the page
        services.AddTransient<PageCssService>();
        services.AddTransient<ThemeJsService>();

        // Logic parts for Controls
        services.AddTransient<PageEditService>();
        services.AddTransient<LanguageService>();

    }
}
