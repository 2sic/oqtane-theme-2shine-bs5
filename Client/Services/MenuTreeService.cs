using Oqtane.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Oqtane.UI;
using static ToSic.Oqt.Themes.ToShineBs5.Client.ThemeCss;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services;

/// <summary>
/// Will create a MenuTree based on the current pages information and configuration
/// </summary>
public class MenuTreeService
{
    public MenuTreeService(SettingsFromJsonService jsonConfigService)
    {
        _jsonConfig = jsonConfigService;
    }
    private readonly SettingsFromJsonService _jsonConfig;

    [return: NotNull]
    public MenuTree GetTree(MenuConfig config, PageState pageState, List<Page> menuPages)
    {
        config ??= new MenuConfig();
        var debugInfo = $"Initial Config: '{config.ConfigName}'";
        var configName = string.IsNullOrWhiteSpace(config.ConfigName) ? MenuDefault : config.ConfigName;
        if (configName != config.ConfigName)
            debugInfo += $"; Config changed to '{configName}'";

        // If the user didn't specify a config name in the Parameters or the config name
        // isn't contained in the json file the normal parameter are given to the service
        if (_jsonConfig.HasMenu(configName))
        {
            config = _jsonConfig.GetMenu(configName).Overrule(config);
            debugInfo += "; Config loaded from Json";
        }

        // See if we have a default configuration for CSS which should be applied
        var designName = config.Design;
        debugInfo += $"; Design: '{designName}'";
        if (string.IsNullOrWhiteSpace(designName))
        {
            designName = configName;
            debugInfo += $"; Design changed to '{designName}'";
        }

        // Usually there is no Design-object pre-filled, in which case we should
        // 1. try to find it in json
        // 2. use the one from the configuration
        if (config.MenuCss == null)
        {
            // Check various places where design could be configured by priority
            var (designConfig, source) = FindBestDesignConfig(designName);
            debugInfo += $"; Design config loaded from '{source}'";

            config = config.Overrule(new MenuConfig(config) { MenuCss = designConfig });
        }
        else
            debugInfo += "; Design rules already set";

        debugInfo = pageState.UserIsAdmin() ? debugInfo : null;

        return new MenuTree(config, pageState.Pages, menuPages, pageState.Page, debugInfo);
    }

    private (MenuDesign, string) FindBestDesignConfig(string designName)
    {
        var designConfig = _jsonConfig.GetDesign(designName);
        if (designConfig != null) return (designConfig, designName + " (json)");

        designConfig = (MenuDesignDefaults.TryGetValue(designName, out var defDesign) ? defDesign : null);
        if (designConfig != null) return (designConfig, designName + " (preset)");

        designConfig = _jsonConfig.GetDesign(MenuDesignDefault);
        if (designConfig != null) return (designConfig, MenuDesignDefault + " (json)");

        designConfig = MenuDesignFallback;
        return (designConfig, MenuDesignDefault + " (preset)");
    }
}