using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.ThemeSettings;

public partial class MenuSettings
{
    [Inject]
    public ThemeSettingsService SettingsService { get; set; }

    [Parameter()]
    public string ConfigName { get; set; }

    public string StartingPage = null;

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

    public int LevelSkip = 0;

    public int LevelDepth;

    public bool Display;

    public string Variation;

    //Scope is static at the moment
    public string Scope = "Site";

    private ThemeDisplaySettings Settings = new ThemeDisplaySettings();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        var dictionary = SettingsService.DeserializeData();
        if(dictionary != null)
        {
            if (dictionary.ContainsKey(ConfigName)){
                var settings = dictionary[ConfigName];

                StartingPage = settings.StartingPage;
                StartLevel = settings.StartLevel;
                PageList = settings.PageList;
                LevelSkip = settings.LevelSkip;
                LevelDepth = settings.LevelDepth;
                Display = settings.Display;
                Variation = settings.Variation;
            }
        }
    }

    private void StartSettings(string StartingPage, int? StartLevel, string PageList, int LevelSkip, int LevelDepth, bool Display, string Variation)
    {
        Settings.StartingPage = StartingPage;
        Settings.StartLevel = StartLevel;
        Settings.PageList = ConvertPageList(PageList);
        Settings.LevelSkip = LevelSkip;
        Settings.LevelDepth = LevelDepth;
        Settings.Display = Display;
        Settings.Variation = Variation;

        SettingsService.SerializeDataAsync(ConfigName, Settings);
    }
}
