using Microsoft.Extensions.DependencyInjection;
using ToSic.Oqt.Themes.ToShineBs5.Client.ThemeSettingsUi;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services;

public class Startup : Oqtane.Services.IClientStartup
{
    /// <summary>
    /// Register Services
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ThemeSettingsServiceWIPToDo>();

        services.AddTransient<MagicThemeJsService>();
        services.AddTransient<IMagicThemeJsService, MagicThemeJsService>();
    }
}
