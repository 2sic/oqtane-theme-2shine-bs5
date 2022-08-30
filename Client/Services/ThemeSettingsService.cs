namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services
{
    public class ThemeSettingsService
    {
        private readonly SettingsFromJsonService _jsonSettings;

        public ThemeSettingsService(SettingsFromJsonService jsonSettings)
        {
            _jsonSettings = jsonSettings;
        }

        public string Logo => ReplacePlaceholders(_jsonSettings.Logo ?? Defaults.DefaultSettings.Layout.Logo);

        private string ReplacePlaceholders(string value) => value?
            .Replace(Defaults.AssetsPathPlaceholder, Defaults.AssetsPath);
    }
}
