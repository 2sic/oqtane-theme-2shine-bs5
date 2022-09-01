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
        services.AddScoped(typeof(ContainerCssService<>));
        services.AddTransient(typeof(PageCssService<>));
        //services.AddScoped<SettingsFromJsonService>();
        //services.AddScoped<ThemeSettingsService>();
        //services.AddScoped<LanguageService>();

        //services.AddTransient<MenuTreeService>();
        //services.AddSingleton<ThemeSettings.ThemeSettingsService>();

        //// Special services for the page
        //services.AddTransient<PageCssService>();
        //services.AddTransient<ThemeJsService>();

        //// Logic parts for Controls
        //services.AddTransient<PageEditService>();

    }
}
