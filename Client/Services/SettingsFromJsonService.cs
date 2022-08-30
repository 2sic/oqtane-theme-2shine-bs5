using System.Text.Json;


namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services
{
    public class SettingsFromJsonService
    {
        public string Logo => _logo ??= JsonConfig.Layout?.Logo;
        private string _logo;

        public bool HasMenu(string name) => !string.IsNullOrWhiteSpace(name)
                                            && (JsonConfig?.Menus?.ContainsKey(name) ?? false);

        public MenuConfig GetMenu(string name)
        {
            if (!HasMenu(name)) return null;
            var config = JsonConfig.Menus[name];
            if (config.ConfigName != name)
                config.ConfigName = name;
            return config;
        }

        public bool HasDesign(string name) => !string.IsNullOrWhiteSpace(name)
                                              && (JsonConfig?.Designs?.ContainsKey(name) ?? false);

        public MenuDesign GetDesign(string name) => HasDesign(name) ? JsonConfig.Designs[name] : null;

        protected SettingsJson JsonConfig => _settingsJson ??= LoadJson();
        private SettingsJson _settingsJson;

        private SettingsJson LoadJson()
        {
            var jsonFileName = $"{Defaults.WwwRoot}/{Defaults.ThemePath}/{Defaults.NavigationJsonFile}";
            try
            {
                var jsonString = System.IO.File.ReadAllText(jsonFileName);
                
                var result = JsonSerializer.Deserialize<SettingsJson>(jsonString, new JsonSerializerOptions
                {
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    AllowTrailingCommas = true,
                })!;

                return result;
            }
            catch
            {
                throw;//wip
                // probably no json file found?
                return new SettingsJson();
            }
        }

    }
}
