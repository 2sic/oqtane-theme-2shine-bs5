using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Oqtane.Themes.Controls;
using ToSic.Oqt.Themes.ToShineBs5.Client.Nav;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu;

public abstract class NavEntryBase : MenuBase
{
    [Inject]
    public PageNavigatorService Navigator { get; set; }

    [Parameter()]
    public string StartingPage { get; set; } = null;
    [Parameter()]
    public int? StartLevel { get; set; } = null!;
    [Parameter()]
    public List<int> PageList { get; set; } = null;

    [Parameter()]
    public int LevelSkip { get; set; } = 0;
    [Parameter()]
    public int LevelDepth { get; set; }

    [Parameter()]
    public bool Display { get; set; } = true;
    [Parameter()]
    public string Variation { get; set; }
    [Parameter()]
    public string ConfigName { get; set; }


    protected PageNavigator Start { get; private set; }

    protected JsonNav jsonNav;

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        string fileName = "wwwroot/Themes/ToSic.Oqt.Themes.ToShineBs5/navigation.json";

        if (jsonNav == null)
        {
            string jsonString = System.IO.File.ReadAllText(fileName);
            jsonNav = System.Text.Json.JsonSerializer.Deserialize<JsonNav>(jsonString)!;
        }

        //If the user didn't specify a config name in the Parameters or the config name
        //isn't contained in the json file the normal parameter are given to the service
        if (ConfigName == null || jsonNav.NavConfigs.ContainsKey(ConfigName) == false)
        {
            Start = Navigator.Start(MenuPages, LevelDepth, Display, LevelSkip, StartingPage);
        }
        else
        {
            var navConfig = jsonNav.NavConfigs[ConfigName];

            if (StartingPage == null && navConfig.StartingPage != null)
                StartingPage = navConfig.StartingPage;
            else if (StartingPage == null && navConfig.StartingPage != null)
                StartingPage = "*";

            if (StartLevel == null)
                StartLevel = navConfig.StartLevel;

            if (PageList == null)
                PageList = navConfig.PageList;

            if (LevelSkip == 0)
                LevelSkip = navConfig.LevelSkip;

            if (Variation == null && navConfig.Variation != null)
                Variation = navConfig.Variation;

            if (LevelDepth == 0 && navConfig.LevelDepth != null)
                LevelDepth = (int)navConfig.LevelDepth;

            if (Display == true)
                Display = navConfig.Display;

            Start = Navigator.Start(MenuPages, LevelDepth, Display, LevelSkip, StartingPage, StartLevel, PageList);
        }
    }
}