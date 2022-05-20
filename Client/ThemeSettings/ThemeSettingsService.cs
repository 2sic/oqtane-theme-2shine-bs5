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
        Dictionary<string, ThemeDisplaySettings> CombinedSettings;

        private ThemeDisplaySettings Settings;

        private IJSObjectReference BodyClassJS;

        public Dictionary<string, ThemeDisplaySettings> DeserializeData()
        {
            string jsonString = File.ReadAllText("./settings.json");
            return CombinedSettings = JsonSerializer.Deserialize<Dictionary<string, ThemeDisplaySettings>>(jsonString);
        }

        public void SerializeDataAsync(string ConfigName, ThemeDisplaySettings Settings)
        {
            CombinedSettings.Add(ConfigName, Settings);

            string jsonString = JsonSerializer.Serialize(CombinedSettings);
            File.WriteAllText("./settings.json", jsonString);
        }
    }
}
