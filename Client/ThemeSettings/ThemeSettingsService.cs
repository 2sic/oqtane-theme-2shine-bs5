using System; 
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;


namespace ToSic.Oqt.Themes.ToShineBs5.Client.ThemeSettings
{
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
            string[] pages = ListString.Split(",");
            List<int> PageList = new List<int>();
            foreach (var page in pages)
            {
                if (Int32.TryParse(page, out int j))
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
  public sealed class ThemeSettingsService
  {
    Dictionary<string, ThemeSettingsContainer> CombinedSettings; 

    public ThemeSettingsContainer DeserializeData(string ConfigName){
      var jsonString = System.IO.File.ReadAllText("wwwroot/Themes/ToSic.Oqt.Themes.ToShineBs5/settings.json");
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
        string jsonString = JsonSerializer.Serialize(CombinedSettings, options);
        await File.WriteAllTextAsync("wwwroot/Themes/ToSic.Oqt.Themes.ToShineBs5/settings.json", jsonString);
    }
  }
}