using System;
using System.Linq;
using static ToSic.Oqt.Themes.ToShineBs5.Client.Defaults;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services;
using static ThemeCss;
/// <summary>
/// Service which consolidates settings made in the UI, in the JSON and falls back to coded defaults.
/// </summary>
public class ThemeSettingsService
{
    internal SettingsFromJsonService Json { get; }

    public ThemeSettingsService(SettingsFromJsonService jsonService)
    {
        Json = jsonService;
    }

    private const string SourceJson = "(json)";
    private const string SourcePreset = "(preset)";

    public string Logo => ReplacePlaceholders(Json.Settings?.Layout?.Logo ?? DefaultThemeSettings.Layout.Logo);

    public (MenuConfig MenuConfig, string Source) FindMenu(string name)
    {
        var names = new List<string> { name, MenuDefault };
        var (result, foundName, sourceInfo) = FindInSources(names, (settings, n) => settings.GetMenu(n));
        return (SyncName(result, foundName), sourceInfo);

        var sources = new List<Internal.Settings.ThemeSettings>
        {
            // TODO: in future also add the settings from the dialog as the first priority
            Json.Settings,
            DefaultThemeSettings
        };



        //var sourcesAndNames = new List<(Internal.Settings.ThemeSettings Settings, string Name)>
        //{
        //    (Json.Settings, name),
        //    (DefaultThemeSettings, name),
        //    (Json.Settings, MenuDefault),
        //    (DefaultThemeSettings, MenuDefault)
        //};

        var allSourcesAndNames = names
            .SelectMany(name => sources.Select(settings => (Settings: settings, Name: name)));

        var cnf = allSourcesAndNames.FirstOrDefault(set => set.Settings?.GetMenu(set.Name) != null);
        if (cnf == default) throw new Exception($"Tried to find {nameof(MenuConfig)} '{name}' and '{MenuDefault}' but got nothing, not even a fallback/default.");
        return (SyncName(cnf.Settings.GetMenu(cnf.Name), cnf.Name), $"Menu: {name} - found '{cnf.Name}' {cnf.Settings.Source}");
    }

    public (T Result, string Name, string source) FindInSources<T>(List<string> names, Func<Internal.Settings.ThemeSettings, string, T> findFunc)
    {
        var sources = new List<Internal.Settings.ThemeSettings>
        {
            // TODO: in future also add the settings from the dialog as the first priority
            Json.Settings,
            DefaultThemeSettings
        };

        var allSourcesAndNames = names
            .SelectMany(name => sources.Select(settings => (Settings: settings, Name: name)))
            .ToList();

        foreach (var set in allSourcesAndNames)
        {
            var result = findFunc(set.Settings, set.Name);
            if (result != null) return (result, set.Name, $"found in '{set.Name}' ({set.Settings.Source})");
        }

        //var cnf = allSourcesAndNames.FirstOrDefault(set => set.Settings?.GetMenu(set.Name) != null);
        //if (cnf == default) 
        throw new Exception($"Tried to find {nameof(T)} in the keys {string.Join(",", names)} but got nothing, not even a fallback/default.");
        // return (SyncName(cnf.Settings.GetMenu(cnf.Name), cnf.Name), $"Menu: {name} - found '{cnf.Name}' {cnf.Settings.Source}");

    }

    private MenuConfig SyncName(MenuConfig config, string name)
    {
        if (config.ConfigName != name) config.ConfigName = name;
        return config;
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
        if(string.IsNullOrWhiteSpace(designName))
            return (DefaultThemeSettings.GetDesign(MenuDesignDefault), MenuDesignDefault + " (default because empty)");

        var designConfig = Json.Settings?.GetDesign(designName);
        if (designConfig != null) return (designConfig, designName + " (json)");

        designConfig = DefaultThemeSettings.GetDesign(designName);
        if (designConfig != null) return (designConfig, designName + " (preset)");

        designConfig = Json.Settings?.GetDesign(MenuDesignDefault);
        if (designConfig != null) return (designConfig, MenuDesignDefault + " (json)");

        designConfig = MenuDesignFallback;
        return (designConfig, MenuDesignDefault + " (preset)");
    }


    private string ReplacePlaceholders(string value) => value?
        .Replace(AssetsPathPlaceholder, AssetsPath);
}