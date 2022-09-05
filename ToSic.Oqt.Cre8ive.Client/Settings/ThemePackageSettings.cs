﻿using ToSic.Oqt.Cre8ive.Client.Styling;

namespace ToSic.Oqt.Cre8ive.Client.Settings;

/// <summary>
/// Settings for a Theme Package.
///
/// Contains semi-constants like location of assets and configuration for various parts like CSS.
/// </summary>
public partial class ThemePackageSettings
{
    /// <summary>
    /// Classes and similar to add to the page.
    /// </summary>
    public virtual PageStyling Page { get; set; } = new();

    /// <summary>
    /// All kinds of settings for the layout, how it should be etc.
    /// Should usually only serve as backup in case the JSON fails.
    /// </summary>
    public virtual CatalogOfSettings Defaults { get; set; } = new();

    public string WwwRoot { get; set; } = "wwwroot";

    public string SettingsJsonFile { get; set; } = "theme-settings.json";

    public string ThemePackageName { get; set; } = "todo: set theme package name in your constructor";

    public string PathAssets
    {
        get => _assetsPath ??= PathTheme + "/Assets";
        set => _assetsPath = value;
    }

    public string PathTheme
    {
        get => _themePath ??= "Themes/" + ThemePackageName;
        set => _themePath = value;
    }
    private string? _assetsPath;
    private string? _themePath;
}