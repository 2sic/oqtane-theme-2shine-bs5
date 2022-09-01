using System.Text.Json;


namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services
{
    public class SettingsFromJsonService
    {
        public string Logo => _logo ??= Settings.Layout?.Logo;
        private string _logo;

        public Cre8ive.Client.Settings.ThemeSettings Settings => _settings ??= LoadJson();
        private Cre8ive.Client.Settings.ThemeSettings _settings;

        private Cre8ive.Client.Settings.ThemeSettings LoadJson()
        {
            var jsonFileName = $"{Defaults.WwwRoot}/{Defaults.ThemePath}/{Defaults.NavigationJsonFile}";
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
}
