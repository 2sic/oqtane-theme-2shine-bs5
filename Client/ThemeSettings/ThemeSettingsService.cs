using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.ThemeSettings
{
    public sealed class ThemeSettingsService
    {
        Dictionary<string, ThemeSettings> CombinedSettings;

        private ThemeSettings Settings;

        private IJSObjectReference BodyClassJS;

        public Dictionary<string, ThemeSettings> DeserializeData()
        {
            string jsonString = File.ReadAllText("../../oqt-theme-2shine-bs5/Client/settings.json");
            return CombinedSettings = JsonSerializer.Deserialize<Dictionary<string, ThemeSettings>>(jsonString);
        }

        public void SerializeDataAsync(string ConfigName, ThemeSettings Settings)
        {
            CombinedSettings.Add(ConfigName, Settings);

            string jsonString = JsonSerializer.Serialize(CombinedSettings);
            File.WriteAllText("../../oqt-theme-2shine-bs5/Client/settings.json", jsonString);
        }
    }
}
