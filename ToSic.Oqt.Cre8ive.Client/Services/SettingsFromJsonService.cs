using System.Text.Json;

namespace ToSic.Oqt.Cre8ive.Client.Services;

public class SettingsFromJsonService : IHasSettingsExceptions
{
    //public SettingsFromJsonService(T settings) => CurrentThemeSettings = settings;
    //public T CurrentThemeSettings { get; }

    //public LayoutsSettings? Settings => _settings ??= LoadJson();
    //private LayoutsSettings? _settings;

    public LayoutsSettings? LoadJson(ThemePackageSettingsBase themeConfig)
    {
        var jsonFileName = $"{themeConfig.WwwRoot}/{themeConfig.PathTheme}/{themeConfig.SettingsJsonFile}";
        try
        {
            var jsonString = File.ReadAllText(jsonFileName);
                
            var result = JsonSerializer.Deserialize<LayoutsSettings>(jsonString, new JsonSerializerOptions
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
            Exceptions.Add(new($"Error loading json configuration file '{themeConfig.SettingsJsonFile}'. {ex.Message}"));
            //throw;//wip
            // probably no json file found?
            return new LayoutsSettings();
        }
    }

    public List<SettingsException> Exceptions => _exceptions ??= new();
    private List<SettingsException>? _exceptions;
}