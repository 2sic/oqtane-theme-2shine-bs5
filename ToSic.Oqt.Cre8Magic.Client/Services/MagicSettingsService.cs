using Oqtane.UI;
using ToSic.Oqt.Cre8Magic.Client.Styling;
using static ToSic.Oqt.Cre8Magic.Client.MagicConstants;
using static ToSic.Oqt.Cre8Magic.Client.Settings.MagicPackageSettings;

namespace ToSic.Oqt.Cre8Magic.Client.Services;

/// <summary>
/// Service which consolidates settings made in the UI, in the JSON and falls back to coded defaults.
/// </summary>
public class MagicSettingsService: IHasSettingsExceptions
{
    /// <summary>
    /// Constructor
    /// </summary>
    public MagicSettingsService(MagicSettingsJsonService jsonService)
    {
        Json = jsonService;
    }

    public MagicSettingsService InitSettings(MagicPackageSettings themeSettings)
    {
        PackageSettings = themeSettings;
        return this;
    }

    public MagicPageDesigner PageDesigner { get; } = new();


    private MagicPackageSettings PackageSettings
    {
        get => _settings ?? throw new ArgumentException($"The {nameof(MagicSettingsService)} can't work without first calling {nameof(InitSettings)}", nameof(PackageSettings));
        set => _settings = value;
    }

    private MagicSettingsJsonService Json { get; }

    public MagicSettings CurrentSettings(PageState pageState, string name, string bodyClasses)
    {
        // Get a cache-id for this specific configuration, which can vary by page
        var originalNameForCache = (name ?? "prevent-error") + pageState.Page.PageId;
        var cached = _currentSettingsCache.FindInvariant(originalNameForCache);
        if (cached != null) return cached;

        var configName = FindConfigName(name, Default);
        name = configName.ConfigName;
        var layout = FindLayout(name).Layout;

        // BreadcrumbSettings
        var breadcrumbNames = GetConfigNamesToCheck(layout.Breadcrumbs, name);
        var breadcrumb = new MagicBreadcrumbSettings
        {
            Separator = FindValue((s, n) => s.Breadcrumbs?.GetInvariant(n)?.Separator, breadcrumbNames)!,
            Revealer = FindValue((s, n) => s.Breadcrumbs?.GetInvariant(n)?.Revealer, breadcrumbNames)!,
        };

        // Language Settings
        var languagesNames = GetConfigNamesToCheck(layout.Languages, name);
        var languages = FindLanguageSettings(languagesNames);

        // Get language design from configuration - keep the first which has any settings
        // This also means no partial inheritance, it's all or nothing
        var langDesignNames = GetConfigNamesToCheck(layout.LanguageMenuDesign, name);
        var langDesign = FindInSources((s, n) =>
        {
            var found = s.LanguageDesigns?.GetInvariant(n);
            return found is { } && found.Any() ? found : null;
        }, langDesignNames);

        // Container Design
        var containerDesignNames = GetConfigNamesToCheck(layout.ContainerDesign, name);
        var containerDesign = FindInSources((s, n) =>
        {
            var found = s.ContainerDesigns?.GetInvariant(n);
            return found is { } && found.Any() ? found : null;
        }, containerDesignNames);

        // Page Design
        var pageDesignNames = GetConfigNamesToCheck(layout.PageDesign, name);
        var pageDesign = FindInSources((s, n) => s.PageDesigns?.GetInvariant(n), pageDesignNames);

        var current = new MagicSettings(name, this, layout, breadcrumb, pageDesign.Result, languages.Languages, langDesign.Result, containerDesign.Result);
        PageDesigner.InitSettings(current);
        current.MagicContext = PageDesigner.BodyClasses(pageState, bodyClasses);
        current.DebugSources.Add("Name", configName.Source);
        current.DebugSources.Add(nameof(current.Languages), languages.Source);
        current.DebugSources.Add(nameof(current.LanguageDesign), langDesign.Source);
        current.DebugSources.Add(nameof(current.ContainerDesign), containerDesign.Source);

        _currentSettingsCache[originalNameForCache] = current;
        return current;
    }

    private readonly NamedSettings<MagicSettings> _currentSettingsCache = new();

    private static string[] GetConfigNamesToCheck(string? configuredNameOrNull, string currentName)
    {
        if (configuredNameOrNull == Inherit) configuredNameOrNull = currentName;

        return string.IsNullOrWhiteSpace(configuredNameOrNull) 
            ? new[] { Default }
            : new[] { configuredNameOrNull, Default }.Distinct().ToArray();
    }

    public (MagicLayoutSettings Layout, string Source) FindLayout(string name)
    {
        var cached = _layoutSettingsCache.FindInvariant(name);
        if (cached != null) return (cached, "cached");
        var names = GetConfigNamesToCheck(name, name);
        var layoutSettings = new MagicLayoutSettings
        {
            ContainerDesign = FindValue((set, n) => set.Layouts?.GetInvariant(n)?.ContainerDesign, names),
            Languages = FindValue((set, n) => set.Layouts?.GetInvariant(n)?.Languages, names),
            LanguageMenuShowMin = FindValue((set, n) => set.Layouts?.GetInvariant(n)?.LanguageMenuShowMin, names) ?? 0,
            LanguageMenuShow = FindValue((set, n) => set.Layouts?.GetInvariant(n)?.LanguageMenuShow, names) ?? true,
            LanguageMenuDesign = FindValue((set, n) => set.Layouts?.GetInvariant(n)?.LanguageMenuDesign, names),
            Breadcrumbs = FindValue((set, n) => set.Layouts?.GetInvariant(n)?.Breadcrumbs, names),
            Logo = ReplacePlaceholders(FindValue((s, n) => s.Layouts?.GetInvariant(n)?.Logo, names)!),
            // Check if we have a menu map
            Menus = FindValue((set, n) =>
            {
                var menu = set.Layouts?.GetInvariant(n)?.Menus;
                return menu != null && menu.Any() ? menu : null;
            }, names)!,
            MagicContextInBody = FindValue((set, n) => set.Layouts?.GetInvariant(n)?.MagicContextInBody, names) ?? false,
        };
        _layoutSettingsCache[name] = layoutSettings;
        return (layoutSettings, "various");
    }

    private readonly NamedSettings<MagicLayoutSettings> _layoutSettingsCache = new();

    public (MagicLanguagesSettings Languages, string Source) FindLanguageSettings(string[] languagesNames)
    {
        var (config, _, sourceInfo) 
            = FindInSources((settings, n) =>
            {
                var tryToFind = settings.Languages?.GetInvariant(n);
                return tryToFind?.List?.Any() == true ? tryToFind : null;
            }, languagesNames);
        if (config == null) throw new NullReferenceException($"{nameof(config)} should be a {nameof(MagicLanguage)}");
        return (config, sourceInfo);
    }

    public (MagicMenuSettings MenuConfig, string Source) FindMenuConfig(string name)
    {
        // Only search multiple names if the name is not already default
        var names = name == Default ? new[] { name } : new[] { name, Default };
        var (config, foundName, sourceInfo) 
            = FindInSources((settings, n) => settings?.Menus?.GetInvariant(n), names);
        
        if (config == null) throw new NullReferenceException($"{nameof(config)} should be a {nameof(MagicMenuSettings)}");
        if (config.ConfigName != foundName) config.ConfigName = foundName;
        return (config, sourceInfo);
    }


    internal (string ConfigName, string Source) FindConfigName(string? configName, string inheritedName)
    {
        var debugInfo = $"Initial Config: '{configName}'";
        if (configName.EqInvariant(Inherit))
        {
            configName = inheritedName;
            debugInfo += $"; switched to inherit '{inheritedName}'";
        }
        if (!string.IsNullOrWhiteSpace(configName)) return (configName, debugInfo);

        debugInfo += $"; Config changed to '{Default}'";
        return (Default, debugInfo);
    }

    internal (MagicMenuDesignSettings Design, string Source) FindDesign(string designName)
    {
        var (result, _, sourceInfo) 
            = FindInSources((settings, n) => settings.MenuDesigns?.GetInvariant(n), designName, Default);
        if (result == null) throw new NullReferenceException($"{nameof(result)} should be a {nameof(MagicMenuDesignSettings)}");
        return (result, sourceInfo);
    }


    private string ReplacePlaceholders(string value) => value
        .Replace(MagicPlaceholders.AssetsPath, PackageSettings.PathAssets);


    private TResult FindValue<TResult>(Func<MagicSettingsCatalog, string, TResult> findFunc, params string[]? names)
    {
        var (showMin, _, _) = FindInSources(findFunc, names);
        return showMin;
    }

    /// <summary>
    /// Loop through various sources of settings and check the keys in the preferred order to see if we get a hit.
    /// </summary>
    private (TResult Result, string Name, string Source) FindInSources<TResult>(
        Func<MagicSettingsCatalog, string, TResult> findFunc,
        params string[]? names)
    {

        // TODO
        // - After that work on making this less generic again, 
        // Basically the tree service should get the settings or something from a non generic class
        // Which the default.razor will prepare / hand through the stack
        var sources = ConfigurationSources;

        // Make sure we have at least on name
        if (names == null || names.Length == 0) names = new[] { Default };

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

    private List<MagicSettingsCatalog> ConfigurationSources
    {
        get
        {
            if (_configurationSources != null) return _configurationSources;
            var sources = new List<MagicSettingsCatalog?>
                {
                    // in future also add the settings from the dialog as the first priority
                    Json.LoadJson(PackageSettings),
                    PackageSettings.Defaults,
                    Fallback.Defaults,
                }
                .Where(x => x != null)
                .Cast<MagicSettingsCatalog>()
                .ToList();
            return _configurationSources = sources;
        }
    }

    private List<MagicSettingsCatalog>? _configurationSources;

    public List<SettingsException> Exceptions => MyExceptions.Concat(Json.Exceptions).ToList();
    private List<SettingsException> MyExceptions => _myExceptions ??= new();
    private List<SettingsException>? _myExceptions;
    private MagicPackageSettings _settings;
}