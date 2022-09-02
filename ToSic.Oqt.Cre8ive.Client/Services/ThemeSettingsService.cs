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

    public CurrentSettings CurrentSettings(string name)
    {
        name ??= Constants.Default;
        var layout = FindLayout(name).Layout;

        var breadcrumbName = layout.Breadcrumbs;
        if (breadcrumbName == Constants.Inherit) breadcrumbName = name;

        // WIP
        var names = new[] { breadcrumbName!, Constants.Default };

        var breadcrumb = new BreadcrumbSettings
        {
            Separator = FindValue((s, n) => s.GetBreadcrumb(n)?.Separator, names)
                                  ?? BreadcrumbSettings.BreadcrumbSeparatorDefault,
            Revealer = FindValue((s, n) => s.GetBreadcrumb(n)?.Revealer, names) 
                               ?? BreadcrumbSettings.BreadcrumbRevealDefault,
        };


        return new CurrentSettings(layout, breadcrumb);
    }

    public (LayoutSettings Layout, string Source) FindLayout(string name)
    {
        if (_layoutSettings != null) return (_layoutSettings, "cached");
        _layoutSettings = new LayoutSettings
        {
            LanguageMenuShowMin = FindValue((settings, _) => settings.Layout?.LanguageMenuShowMin) ?? 0,
            LanguageMenuShow = FindValue((settings, _) => settings.Layout?.LanguageMenuShow) ?? true,
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
            = FindInSources((settings, n) => settings.GetMenu(n), names);
        
        if (config == null) throw new NullReferenceException($"{nameof(config)} should be a {nameof(MenuConfig)}");
        if (config.ConfigName != foundName) config.ConfigName = foundName;
        return (config, sourceInfo);
    }


    public (string ConfigName, string Source) FindConfigName(string? originalName)
    {
        var debugInfo = $"Initial Config: '{originalName}'";
        var configName = string.IsNullOrWhiteSpace(originalName) ? Constants.Default : originalName;
        if (configName != originalName)
            debugInfo += $"; Config changed to '{configName}'";

        return (configName, debugInfo);
    }

    public (MenuDesignSettings Design, string Source) FindDesign(string designName)
    {
        var (result, _, sourceInfo) 
            = FindInSources((settings, n) => settings.GetDesign(n), designName, Constants.Default);
        if (result == null) throw new NullReferenceException($"{nameof(result)} should be a {nameof(MenuDesignSettings)}");
        return (result, sourceInfo);
    }


    private string ReplacePlaceholders(string value) => value
        .Replace(Placeholders.AssetsPath, _settings.PathAssets);


    private TResult FindValue<TResult>(Func<LayoutsSettings, string, TResult> findFunc, params string[]? names)
    {
        var (showMin, _, _) = FindInSources(findFunc, names);
        return showMin;
    }

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
                _settings.Defaults,
                ThemePackageSettingsBase.Fallback.Defaults,
            }
            .Where(x => x != null)
            .Cast<LayoutsSettings>()
            .ToList();

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