using System.Text.Json;

namespace ToSic.Oqt.Cre8ive.Client.Services;

public class SettingsFromJsonService<T>: IHasSettingsExceptions where T : ThemePackageSettingsBase, new()
{
    public SettingsFromJsonService(T settings) => CurrentThemeSettings = settings;
    public T CurrentThemeSettings { get; }

    public LayoutSettings? Settings => _settings ??= LoadJson();
    private LayoutSettings? _settings;

    private LayoutSettings? LoadJson()
    {
        var jsonFileName = $"{CurrentThemeSettings.WwwRoot}/{CurrentThemeSettings.PathTheme}/{CurrentThemeSettings.SettingsJsonFile}";
        try
        {
            var jsonString = File.ReadAllText(jsonFileName);
                
            var result = JsonSerializer.Deserialize<LayoutSettings>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true,
            })!;

            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (result != null && !result.Source.HasValue())
                result.Source = "JSON";

            return result;
        }
        catch (Exception ex)
        {
            Exceptions.Add(new($"Error loading json configuration file '{CurrentThemeSettings.SettingsJsonFile}'. {ex.Message}"));
            //throw;//wip
            // probably no json file found?
            return new LayoutSettings();
        }
    }

    public List<SettingsException> Exceptions => _exceptions ??= new();
    private List<SettingsException>? _exceptions;
}