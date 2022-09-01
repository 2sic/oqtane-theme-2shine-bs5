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

        services.AddSingleton<ThemeSettings.ThemeSettingsServiceWIPToDo>();

        services.AddTransient<ThemeJsService>();

        // Defaults-Service
        services.AddSingleton<ThemePackageSettings>();
    }
}
