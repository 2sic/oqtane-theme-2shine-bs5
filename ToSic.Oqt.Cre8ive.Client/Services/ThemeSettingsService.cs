using static ToSic.Oqt.Cre8ive.Client.Settings.ThemePackageSettings;

namespace ToSic.Oqt.Cre8ive.Client.Services;

/// <summary>
/// Service which consolidates settings made in the UI, in the JSON and falls back to coded defaults.
/// </summary>
public class ThemeSettingsService: IHasSettingsExceptions
{
    /// <summary>
    /// Constructor
    /// </summary>
    public ThemeSettingsService(SettingsFromJsonService jsonService)
    {
        Json = jsonService;
    }

    public void InitSettings(ThemePackageSettings themeSettings)
    {
        Settings = themeSettings;
    }

    private ThemePackageSettings Settings
    {
        get => _settings ?? throw new ArgumentException($"The {nameof(ThemeSettingsService)} can't work without first calling {nameof(InitSettings)}", nameof(Settings));
        set => _settings = value;
    }

    private SettingsFromJsonService Json { get; }

    public CurrentSettings CurrentSettings(string name)
    {
        var configName = FindConfigName(name);
        name = configName.ConfigName;
        var layout = FindLayout(name).Layout;

        var breadcrumbNames = GetConfigNamesToCheck(layout.Breadcrumbs, name);

        var breadcrumb = new BreadcrumbSettings
        {
            Separator = FindValue((s, n) => s.Breadcrumbs?.GetInvariant(n)?.Separator, breadcrumbNames)
                                  ?? BreadcrumbSettings.BreadcrumbSeparatorDefault,
            Revealer = FindValue((s, n) => s.Breadcrumbs?.GetInvariant(n)?.Revealer, breadcrumbNames) 
                               ?? BreadcrumbSettings.BreadcrumbRevealDefault,
        };

        var languages = FindLanguageSettings();

        // Get language design from configuration - keep the first which has any settings
        // This also means no partial inheritance, it's all or nothing
        var langDesignNames = GetConfigNamesToCheck(layout.LanguageMenuDesign, name);
        var langDesign = FindInSources((s, n) =>
        {
            var found = s.LanguageDesigns?.GetInvariant(n);
            return found is { Styling: { } } && found.Styling.Any() ? found : null;
        }, langDesignNames);

        var containerDesignNames = GetConfigNamesToCheck(layout.ContainerDesign, name);
        var containerDesign = FindInSources((s, n) =>
        {
            var found = s.ContainerDesigns?.GetInvariant(n);
            return found is { Styling: { } } && found.Styling.Any() ? found : null;
        }, containerDesignNames);

        var current = new CurrentSettings(this, layout, breadcrumb, Settings.Css, languages.Languages, langDesign.Result, containerDesign.Result);
        current.DebugSources.Add("Name", configName.Source);
        current.DebugSources.Add(nameof(current.Languages), languages.Source);
        current.DebugSources.Add(nameof(current.LanguageDesign), langDesign.Source);
        return current;
    }

    private static string[] GetConfigNamesToCheck(string? configuredNameOrNull, string currentName)
    {
        if (configuredNameOrNull == Constants.Inherit) configuredNameOrNull = currentName;

        return string.IsNullOrWhiteSpace(configuredNameOrNull) 
            ? new[] { Constants.Default }
            : new[] { configuredNameOrNull, Constants.Default }.Distinct().ToArray();
    }

    public (LayoutSettings Layout, string Source) FindLayout(string name)
    {
        if (_layoutSettings != null) return (_layoutSettings, "cached");
        _layoutSettings = new LayoutSettings
        {
            ContainerDesign = FindValue((settings, _) => settings.Layout?.ContainerDesign),
            LanguageMenuShowMin = FindValue((settings, _) => settings.Layout?.LanguageMenuShowMin) ?? 0,
            LanguageMenuShow = FindValue((settings, _) => settings.Layout?.LanguageMenuShow) ?? true,
            LanguageMenuDesign = FindValue((settings, _) => settings.Layout?.LanguageMenuDesign),
            Breadcrumbs = FindValue((settings, _) => settings.Layout?.Breadcrumbs),
            Logo = ReplacePlaceholders(FindValue((s, _) => s.Layout?.Logo)!),
        };
        return (_layoutSettings, "various");
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
        var names = name == Constants.Default ? new[] { name } : new[] { name, Constants.Default };
        var (config, foundName, sourceInfo) 
            = FindInSources((settings, n) => settings?.Menus?.GetInvariant(n), names);
        
        if (config == null) throw new NullReferenceException($"{nameof(config)} should be a {nameof(MenuConfig)}");
        if (config.ConfigName != foundName) config.ConfigName = foundName;
        return (config, sourceInfo);
    }


    public (string ConfigName, string Source) FindConfigName(string? configName)
    {
        var debugInfo = $"Initial Config: '{configName}'";
        if (!string.IsNullOrWhiteSpace(configName)) return (configName, debugInfo);

        debugInfo += $"; Config changed to '{Constants.Default}'";
        return (Constants.Default, debugInfo);
    }

    public (MenuDesignSettings Design, string Source) FindDesign(string designName)
    {
        var (result, _, sourceInfo) 
            = FindInSources((settings, n) => settings.MenuDesigns?.GetInvariant(n), designName, Constants.Default);
        if (result == null) throw new NullReferenceException($"{nameof(result)} should be a {nameof(MenuDesignSettings)}");
        return (result, sourceInfo);
    }


    private string ReplacePlaceholders(string value) => value
        .Replace(Placeholders.AssetsPath, Settings.PathAssets);


    private TResult FindValue<TResult>(Func<LayoutsSettings, string, TResult> findFunc, params string[]? names)
    {
        var (showMin, _, _) = FindInSources(findFunc, names);
        return showMin;
    }

    /// <summary>
    /// Loop through various sources of settings and check the keys in the preferred order to see if we get a hit.
    /// </summary>
    private (TResult Result, string Name, string Source) FindInSources<TResult>(
        Func<LayoutsSettings, string, TResult> findFunc,
        params string[]? names)
    {

        // TODO
        // - After that work on making this less generic again, 
        // Basically the tree service should get the settings or something from a non generic class
        // Which the default.razor will prepare / hand through the stack
        var sources = ConfigurationSources;

        // Make sure we have at least on name
        if (names == null || names.Length == 0) names = new[] { Constants.Default };

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

    private List<LayoutsSettings> ConfigurationSources
    {
        get
        {
            if (_configurationSources != null) return _configurationSources;
            var sources = new List<LayoutsSettings?>
                {
                    // in future also add the settings from the dialog as the first priority
                    Json.LoadJson(Settings),
                    Settings.Defaults,
                    Fallback.Defaults,
                }
                .Where(x => x != null)
                .Cast<LayoutsSettings>()
                .ToList();
            return _configurationSources = sources;
        }
    }

    private List<LayoutsSettings>? _configurationSources;

    public List<SettingsException> Exceptions => MyExceptions.Concat(Json.Exceptions).ToList();
    private List<SettingsException> MyExceptions => _myExceptions ??= new();
    private List<SettingsException>? _myExceptions;
    private ThemePackageSettings _settings;
}