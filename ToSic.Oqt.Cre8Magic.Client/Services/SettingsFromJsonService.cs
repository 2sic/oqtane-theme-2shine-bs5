using System.Text.Json;

namespace ToSic.Oqt.Cre8ive.Client.Services;

public class SettingsFromJsonService : IHasSettingsExceptions
{
    public CatalogOfSettings? LoadJson(ThemePackageSettings themeConfig)
    {
        var jsonFileName = $"{themeConfig.WwwRoot}/{themeConfig.PathTheme}/{themeConfig.SettingsJsonFile}";
        try
        {
            var jsonString = File.ReadAllText(jsonFileName);
                
            var result = JsonSerializer.Deserialize<CatalogOfSettings>(jsonString, new JsonSerializerOptions
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
            return new CatalogOfSettings();
        }
    }

    public List<SettingsException> Exceptions => _exceptions ??= new();
    private List<SettingsException>? _exceptions;
}