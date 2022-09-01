using System;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services;

/// <summary>
/// Service which consolidates settings made in the UI, in the JSON and falls back to coded defaults.
/// </summary>
public class ThemeSettingsService<T> where T : ThemeDefaults, new()
{

    /// <summary>
    /// Constructor
    /// </summary>
    public ThemeSettingsService(SettingsFromJsonService<T> jsonService, T settings)
    {
        _settings = settings;
        Json = jsonService;
    }
    private readonly T _settings;

    private SettingsFromJsonService<T> Json { get; }

    /// <summary>
    /// Get Logo as specified in JSON or preset
    /// </summary>
    public string Logo => ReplacePlaceholders(Json.Settings?.Layout?.Logo ?? _settings.ThemeSettings.Layout.Logo);

    public (SettingsLayout Layout, string Source) FindLayout()
    {
        if (_layoutSettings != null) return (_layoutSettings, "cached");
        var (show, _, showSource)
            = FindInSources((settings, _) => settings.Layout?.LanguageMenuShow);
        var (showMin, _, _)
            = FindInSources((settings, _) => settings.Layout?.LanguageMenuShowMin);
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
            = FindInSources((settings, _) => settings.Languages?.List?.Any() == true ? settings.Languages : null);
        
        return (config, sourceInfo);
    }

    public (MenuConfig MenuConfig, string Source) FindMenuConfig(string name)
    {
        // Only search multiple names if the name is not already default
        var names = name == Constants.MenuDefault ? new[] { name } : new[] { name, Constants.MenuDefault };
        var (config, foundName, sourceInfo) 
            = FindInSources((settings, n) => settings.GetMenu(n), names);
        
        if (config.ConfigName != foundName) config.ConfigName = foundName;
        return (config, sourceInfo);
    }


    public (string ConfigName, string Source) FindConfigName(string originalName)
    {
        var debugInfo = $"Initial Config: '{originalName}'";
        var configName = string.IsNullOrWhiteSpace(originalName) ? Constants.MenuDefault : originalName;
        if (configName != originalName)
            debugInfo += $"; Config changed to '{configName}'";

        return (configName, debugInfo);
    }

    public (MenuDesign Design, string Source) FindDesign(string designName)
    {
        var (result, _, sourceInfo) 
            = FindInSources((settings, n) => settings.GetDesign(n), designName, Constants.DesignDefault);
        return (result, sourceInfo);
    }


    private string ReplacePlaceholders(string value) => value?
        .Replace(Placeholders.AssetsPath, _settings.AssetsPath);

    /// <summary>
    /// Loop through various sources of settings and check the keys in the preferred order to see if we get a hit.
    /// </summary>
    private (TResult Result, string Name, string source) FindInSources<TResult>(
        Func<Cre8ive.Client.Settings.ThemeSettings, string, TResult> findFunc,
        params string[] names)
    {
        var sources = new List<Cre8ive.Client.Settings.ThemeSettings>
        {
            // in future also add the settings from the dialog as the first priority
            Json.Settings,
            _settings.ThemeSettings
        };

        // Make sure we have at least on name
        if (names == null || names.Length == 0) names = new[] { "dummy" };

        var allSourcesAndNames = names
            .Distinct()
            .SelectMany(name => sources.Select(settings => (Settings: settings, Name: name)))
            .ToList();

        foreach (var set in allSourcesAndNames)
        {
            var result = findFunc(set.Settings, set.Name);
            if (result != null) return (result, set.Name, $"found in '{set.Name}' ({set.Settings.Source})");
        }

        throw new Exception($"Tried to find {nameof(TResult)} in the keys {string.Join(",", names)} but got nothing, not even a fallback/default.");
    }
}