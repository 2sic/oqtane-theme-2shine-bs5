using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Oqtane.Themes.Controls;
using ToSic.Oqt.Themes.ToShineBs5.Client.Models;
using ToSic.Oqt.Themes.ToShineBs5.Client.Nav;
using ToSic.Oqt.Themes.ToShineBs5.Client.Services;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu;

public abstract class NavEntryBase : MenuBase, IMenuConfig
{
    [Inject] protected PageNavigatorService Navigator { get; set; }
    [Inject] protected MenuConfigFromJsonService ConfigFromJson { get; set; }


    [Parameter] public string StartPage { get; set; }
    [Parameter] public int? StartLevel { get; set; }
    [Parameter] public List<int> PageList { get; set; }
    [Parameter] public int? LevelSkip { get; set; }
    [Parameter] public int? LevelDepth { get; set; }
    [Parameter] public bool? Display { get; set; } = true;
    //[Parameter] public string Variation { get; set; }
    [Parameter] public string ConfigName { get; set; }


    protected PageNavigator Start { get; private set; }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        var config = new MenuConfig(this);

        // If the user didn't specify a config name in the Parameters or the config name
        // isn't contained in the json file the normal parameter are given to the service
        if (ConfigName != null && ConfigFromJson.JsonConfig.Configurations.ContainsKey(ConfigName))
        {
            var navConfig = ConfigFromJson.JsonConfig.Configurations[ConfigName];
            config = navConfig.Overrule(config);
        }
        

        Start = Navigator.Start(MenuPages, config);
    }
}