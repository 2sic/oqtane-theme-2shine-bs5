using System;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services;
using static Defaults;
using static ThemeCss;

/// <summary>
/// Service which consolidates settings made in the UI, in the JSON and falls back to coded defaults.
/// </summary>
public class ThemeSettingsService
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="jsonService"></param>
    public ThemeSettingsService(SettingsFromJsonService jsonService) => Json = jsonService;
    private SettingsFromJsonService Json { get; }

    /// <summary>
    /// Get Logo as specified in JSON or preset
    /// </summary>
    public string Logo => ReplacePlaceholders(Json.Settings?.Layout?.Logo ?? DefaultThemeSettings.Layout.Logo);

    public (SettingsLayout Layout, string Source) FindLayout()
    {
        if (_layoutSettings != null) return (_layoutSettings, "cached");
        var (show, _, showSource)
            = FindInSources((settings, n) => settings.Layout?.LanguageMenuShow);
        var (showMin, _, sourceInfo)
            = FindInSources((settings, n) => settings.Layout?.LanguageMenuShowMin);
        _layoutSettings = new SettingsLayout
        {
            LanguageMenuShowMin = showMin ?? 0,
            LanguageMenuShow = show ?? true,
        };
        return (_layoutSettings, showSource);
    }

    private SettingsLayout _layoutSettings;

    public (SettingsLanguages Languages, string Source) FindLanguageSettings()
    {
        var (config, _, sourceInfo) 
            = FindInSources((settings, n) => settings.Languages?.List?.Any() == true ? settings.Languages : null);
        
        return (config, sourceInfo);
    }

    public (MenuConfig MenuConfig, string Source) FindMenuConfig(string name)
    {
        var (config, foundName, sourceInfo) 
            = FindInSources((settings, n) => settings.GetMenu(n), name, MenuDefault);
        
        if (config.ConfigName != foundName) config.ConfigName = foundName;
        return (config, sourceInfo);
    }


    public (string ConfigName, string Source) FindConfigName(string originalName)
    {
        var debugInfo = $"Initial Config: '{originalName}'";
        var configName = string.IsNullOrWhiteSpace(originalName) ? MenuDefault : originalName;
        if (configName != originalName)
            debugInfo += $"; Config changed to '{configName}'";

        return (configName, debugInfo);
    }

    public (MenuDesign Design, string Source) FindDesign(string designName)
    {
        var (result, _, sourceInfo) 
            = FindInSources((settings, n) => settings.GetDesign(n), designName, MenuDesignDefault);
        return (result, sourceInfo);
    }


    private string ReplacePlaceholders(string value) => value?
        .Replace(PlaceholderAssetsPath, AssetsPath);

    /// <summary>
    /// Loop through various sources of settings and check the keys in the preferred order to see if we get a hit.
    /// </summary>
    private (T Result, string Name, string source) FindInSources<T>(
        Func<Internal.Settings.ThemeSettings, string, T> findFunc,
        params string[] names)
    {
        var sources = new List<Internal.Settings.ThemeSettings>
        {
            // in future also add the settings from the dialog as the first priority
            Json.Settings,
            DefaultThemeSettings
        };

        if (names == null || names.Length == 0) names = new[] { "dummy" };

        var allSourcesAndNames = names
            .SelectMany(name => sources.Select(settings => (Settings: settings, Name: name)))
            .ToList();

        foreach (var set in allSourcesAndNames)
        {
            var result = findFunc(set.Settings, set.Name);
            if (result != null) return (result, set.Name, $"found in '{set.Name}' ({set.Settings.Source})");
        }

        throw new Exception($"Tried to find {nameof(T)} in the keys {string.Join(",", names)} but got nothing, not even a fallback/default.");
    }
}