﻿using Microsoft.AspNetCore.Components;

namespace ToSic.Oqt.Cre8ive.Client.Services;

/// <summary>
/// Service which consolidates settings made in the UI, in the JSON and falls back to coded defaults.
/// </summary>
public class ThemeSettingsService<T>: IHasSettingsExceptions where T : ThemePackageSettingsBase, new()
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
    public string Logo => ReplacePlaceholders(Json.Settings?.Layout?.Logo ?? _settings.Defaults.Layout?.Logo ?? "default-logo-not-set.jpg");

    public MarkupString BreadcrumbSeparator => (MarkupString)(Json.Settings?.Layout?.BreadcrumbSeparator ??
                                               _settings.Defaults.Layout?.BreadcrumbSeparator ??
                                               LayoutSettings.BreadcrumbSeparatorDefault);
    public MarkupString BreadcrumbReveal => (MarkupString)(Json.Settings?.Layout?.BreadcrumbReveal ??
                                               _settings.Defaults.Layout?.BreadcrumbReveal ??
                                               LayoutSettings.BreadcrumbRevealDefault);

    public (LayoutSettings Layout, string Source) FindLayout()
    {
        if (_layoutSettings != null) return (_layoutSettings, "cached");
        var (show, _, showSource)
            = FindInSources((settings, _) => settings.Layout?.LanguageMenuShow);
        var (showMin, _, _)
            = FindInSources((settings, _) => settings.Layout?.LanguageMenuShowMin);
        _layoutSettings = new LayoutSettings
        {
            LanguageMenuShowMin = showMin ?? 0,
            LanguageMenuShow = show ?? true,
        };
        return (_layoutSettings, showSource);
    }

    private LayoutSettings? _layoutSettings;

    public (LanguagesSettings Languages, string Source) FindLanguageSettings()
    {
        var (config, _, sourceInfo) 
            = FindInSources((settings, _) => settings.Languages?.List?.Any() == true ? settings.Languages : null);
        if (config == null) throw new NullReferenceException($"{nameof(config)} should be a {nameof(Language)}");
        return (config, sourceInfo);
    }

    public (MenuConfig MenuConfig, string Source) FindMenuConfig(string name)
    {
        // Only search multiple names if the name is not already default
        var names = name == Constants.MenuDefault ? new[] { name } : new[] { name, Constants.MenuDefault };
        var (config, foundName, sourceInfo) 
            = FindInSources((settings, n) => settings.GetMenu(n), names);
        
        if (config == null) throw new NullReferenceException($"{nameof(config)} should be a {nameof(MenuConfig)}");
        if (config.ConfigName != foundName) config.ConfigName = foundName;
        return (config, sourceInfo);
    }


    public (string ConfigName, string Source) FindConfigName(string? originalName)
    {
        var debugInfo = $"Initial Config: '{originalName}'";
        var configName = string.IsNullOrWhiteSpace(originalName) ? Constants.MenuDefault : originalName;
        if (configName != originalName)
            debugInfo += $"; Config changed to '{configName}'";

        return (configName, debugInfo);
    }

    public (MenuDesignSettings Design, string Source) FindDesign(string designName)
    {
        var (result, _, sourceInfo) 
            = FindInSources((settings, n) => settings.GetDesign(n), designName, Constants.DesignDefault);
        if (result == null) throw new NullReferenceException($"{nameof(result)} should be a {nameof(MenuDesignSettings)}");
        return (result, sourceInfo);
    }


    private string ReplacePlaceholders(string value) => value
        .Replace(Placeholders.AssetsPath, _settings.PathAssets);

    /// <summary>
    /// Loop through various sources of settings and check the keys in the preferred order to see if we get a hit.
    /// </summary>
    private (TResult Result, string Name, string source) FindInSources<TResult>(
        Func<LayoutsSettings, string, TResult> findFunc,
        params string[]? names)
    {
        var sources = new List<LayoutsSettings?>
        {
            // in future also add the settings from the dialog as the first priority
            Json.Settings,
            _settings.Defaults
        }.Where(x => x != null).Cast<LayoutsSettings>().ToList();

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

    public List<SettingsException> Exceptions => MyExceptions.Concat(Json.Exceptions).ToList();
    private List<SettingsException> MyExceptions => _myExceptions ??= new();
    private List<SettingsException>? _myExceptions;
}