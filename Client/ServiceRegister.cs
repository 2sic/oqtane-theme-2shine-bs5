using Microsoft.Extensions.DependencyInjection;
using ToSic.Oqt.Themes.ToShineBs5.Client.Controls;
using ToSic.Oqt.Themes.ToShineBs5.Client.Layouts;
using ToSic.Oqt.Themes.ToShineBs5.Client.Nav;
using ToSic.Oqt.Themes.ToShineBs5.Client.ThemeSettings;

namespace ToSic.Oqt.Themes.ToShineBs5.Client;

public class ServiceRegister : Oqtane.Services.IClientStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<PageNavigatorService>();
        services.AddSingleton<ThemeSettingsService>();
        services.AddTransient<PageCss>();
        services.AddTransient<AdminActions>();
    }
}
