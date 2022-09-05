﻿using System.Diagnostics.CodeAnalysis;
using Oqtane.Models;
using Oqtane.UI;

namespace ToSic.Oqt.Cre8ive.Client.Services;

/// <summary>
/// Will create a MenuTree based on the current pages information and configuration
/// </summary>
public class MenuTreeService: ServiceWithCurrentSettings
{
    //public void InitSettings(CurrentSettings settings) => Settings ??= settings;
    //public CurrentSettings Settings { get; private set; }


    [return: NotNull]
    public MenuTree GetTree(MenuConfig config, PageState pageState, List<Page> menuPages)
    {
        var settingsSvc = Settings.Service;
        var (configName, debugInfo) = settingsSvc.FindConfigName(config.ConfigName);


        // If the user didn't specify a config name in the Parameters or the config name
        // isn't contained in the json file the normal parameter are given to the service
        var (menuSettings, menuConfigSource) = settingsSvc.FindMenuConfig(configName);
        config = menuSettings.Overrule(config);
        debugInfo += "; " + menuConfigSource;

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
        if (config.DesignSettings == null)
        {
            // Check various places where design could be configured by priority
            var (designConfig, source) = settingsSvc.FindDesign(designName);
            debugInfo += $"; Design config loaded from '{source}'";

            config = config.Overrule(new MenuConfig(config) { DesignSettings = designConfig });
        }
        else
            debugInfo += "; Design rules already set";

        // should be null if not admin, so the final razor doesn't even add the attribute
        debugInfo = pageState.UserIsAdmin() ? debugInfo : null;

        return new MenuTree(config, pageState.Pages, menuPages, pageState.Page, debugInfo, settingsSvc);
    }
}