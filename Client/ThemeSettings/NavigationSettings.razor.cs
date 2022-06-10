using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System.Timers;
using System;
using System.Collections.Generic;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.ThemeSettings;
public partial class NavigationSettings
{
    private System.Timers.Timer myTimer = new System.Timers.Timer();

    [Inject]
    public ThemeSettingsService SettingsService { get; set; }

    [Parameter()]
    public string ConfigName { get; set; }

    ThemeSettingsContainer ThemeSettings = new ThemeSettingsContainer();

    protected override void OnInitialized(){
        base.OnInitialized();
        var Settings = SettingsService.DeserializeData(ConfigName);
        if(Settings != null) {
            ThemeSettings = Settings;
        }
    }

    public async Task UpdateSettings(){
        await SettingsService.UpdateAndSerializeSettings(ConfigName, ThemeSettings);
    }
}