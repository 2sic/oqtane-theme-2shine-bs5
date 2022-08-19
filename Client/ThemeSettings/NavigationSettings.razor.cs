using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System.Timers;
using System;
using System.Collections.Generic;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.ThemeSettings;
public partial class NavigationSettings
{
    [Inject]
    public ThemeSettingsService SettingsService { get; set; }

    [Parameter()]
    public string ConfigName { get; set; }

    public ThemeSettingsContainer ThemeSettings = new ThemeSettingsContainer();

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        var Settings = SettingsService.DeserializeData(ConfigName);
        if (Settings != null)
        {
            ThemeSettings = Settings;
        }
    }

    void OnSettingsChanged(object args)
    {
        bool.TryParse(args.ToString(), out var result);
        ThemeSettings.UseUiSettings = result;

    }

    void OnDisplayChanged(object args)
    {
        bool.TryParse(args.ToString(), out var result);
        ThemeSettings.Display = result;
    }

    void OnScopeChanged(object args)
    {
        bool.TryParse(args.ToString(), out var result);
        ThemeSettings.Display = result;
    }
}