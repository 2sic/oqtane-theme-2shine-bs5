using Oqtane.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Oqtane.UI;
using ToSic.Oqt.Themes.ToShineBs5.Client.Models;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services;

/// <summary>
/// Will create a MenuTree based on the current pages information and configuration
/// </summary>
public class MenuTreeService
{
    public MenuTreeService(MenuConfigFromJsonService jsonConfigService)
    {
        _jsonConfigService = jsonConfigService;
    }
    private readonly MenuConfigFromJsonService _jsonConfigService;

    [return: NotNull]
    public MenuTree GetTree(MenuConfig config, PageState pageState, List<Page> menuPages)
    {
        config ??= new MenuConfig();
        var configName = config.ConfigName;

        // If the user didn't specify a config name in the Parameters or the config name
        // isn't contained in the json file the normal parameter are given to the service
        if (!string.IsNullOrWhiteSpace(configName) && _jsonConfigService.JsonConfig.Configurations.ContainsKey(configName))
        {
            var navConfig = _jsonConfigService.JsonConfig.Configurations[configName];
            config = navConfig.Overrule(config);
        }

        return new MenuTree(config, pageState.Pages, menuPages, pageState.Page);
    }

}