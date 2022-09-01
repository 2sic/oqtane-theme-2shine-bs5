using System.Text.Json;

namespace ToSic.Oqt.Cre8ive.Client.Services;

public class SettingsFromJsonService<T> where T : ThemeDefaults, new()
{
    public SettingsFromJsonService(T settings) => CurrentThemeSettings = settings;
    public T CurrentThemeSettings { get; }

    public string Logo => _logo ??= Settings.Layout?.Logo;
    private string _logo;

    public Cre8ive.Client.Settings.ThemeSettings Settings => _settings ??= LoadJson();
    private Cre8ive.Client.Settings.ThemeSettings _settings;

    private Cre8ive.Client.Settings.ThemeSettings LoadJson()
    {
        var jsonFileName = $"{CurrentThemeSettings.WwwRoot}/{CurrentThemeSettings.ThemePath}/{CurrentThemeSettings.SettingsJsonFile}";
        try
        {
            var jsonString = System.IO.File.ReadAllText(jsonFileName);
                
            var result = JsonSerializer.Deserialize<Cre8ive.Client.Settings.ThemeSettings>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true,
            })!;

            if (result != null)
                result.Source = "JSON";

            return result;
        }
        catch
        {
            throw;//wip
            // probably no json file found?
            return new Cre8ive.Client.Settings.ThemeSettings();
        }
    }

}