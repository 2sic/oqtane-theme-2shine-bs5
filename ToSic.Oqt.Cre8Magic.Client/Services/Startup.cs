using Microsoft.Extensions.DependencyInjection;

namespace ToSic.Oqt.Cre8ive.Client.Services;

public class Startup : Oqtane.Services.IClientStartup
{
    /// <summary>
    /// Register Services
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        // All these Settings etc. should be scoped, so they don't have to reload for each click
        services.AddScoped<SettingsFromJsonService>();
        services.AddScoped<ThemeSettingsService>();
        services.AddTransient<LanguageService>();

        services.AddTransient<MenuTreeService>();

        //// Logic parts for Controls
        services.AddTransient<PageEditService>();

    }
}
