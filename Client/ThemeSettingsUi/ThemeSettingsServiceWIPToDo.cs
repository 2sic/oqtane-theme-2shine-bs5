using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToSic.Themes.ToShineBs5.Client.ThemeSettingsUi;

public class ThemeSettingsContainer
{
    public string StartingPage;

    public int? StartLevel = null!;

    public string PageListString;

    public List<int> PageList;

    public List<int> ConvertPageList(string ListString)
    {
        if (string.IsNullOrEmpty(ListString))
        {
            return null;
        }
        else
        {
            var pages = ListString.Split(",");
            var PageList = new List<int>();
            foreach (var page in pages)
            {
                if (Int32.TryParse(page, out var j))
                {
                    PageList.Add(j);
                }
            }
            return PageList;
        }
    }

    public int LevelSkip;

    public int LevelDepth;

    public bool Display;

    public string Variation;

    //Scope is static at the moment
    public string Scope = "Site";

    public bool UseUiSettings;
}
public sealed class ThemeSettingsServiceWIPToDo
{
    Dictionary<string, ThemeSettingsContainer> CombinedSettings; 

    public ThemeSettingsContainer DeserializeData(string ConfigName){
        var jsonString = File.ReadAllText("wwwroot/Themes/ToSic.Themes.ToShineBs5/settings.json");
        var options = new JsonSerializerOptions
        {
            IncludeFields = true,
        };
        CombinedSettings = JsonSerializer.Deserialize<Dictionary<string, ThemeSettingsContainer>>(jsonString, options);
        if(CombinedSettings.ContainsKey(ConfigName)){
            return CombinedSettings[ConfigName];
        }
        return null;
    }
    
    public async Task UpdateAndSerializeSettings(string ConfigName, ThemeSettingsContainer Settings){
        if(CombinedSettings.ContainsKey(ConfigName)){
            CombinedSettings[ConfigName] = Settings;
        } else {
            CombinedSettings.Add(ConfigName, Settings);
        }
        var options = new JsonSerializerOptions
        {
            IncludeFields = true,
        };
        var jsonString = JsonSerializer.Serialize(CombinedSettings, options);
        await File.WriteAllTextAsync("wwwroot/Themes/ToSic.Themes.ToShineBs5/settings.json", jsonString);
    }
}