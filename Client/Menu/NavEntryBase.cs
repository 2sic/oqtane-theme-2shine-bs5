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
    public string ParentPage { get; set; }

    [Parameter()]
    public string Variation { get; set; }

    [Parameter()]
    public int Levels { get; set; }

    [Parameter()]
    public string ConfigName{ get; set; }

    [Parameter()]
    public int StartLevel { get; set; }

    protected PageNavigator Start { get; private set; }

    protected JsonNav jsonNav;

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        string fileName = "wwwroot/Themes/ToSic.Oqt.Themes.ToShineBs5/navigation.json";

        if(jsonNav == null)
        {
            string jsonString = System.IO.File.ReadAllText(fileName);
            jsonNav = System.Text.Json.JsonSerializer.Deserialize<JsonNav>(jsonString)!;
        }

        if (ConfigName == null)
        {
            Start = Navigator.Start(MenuPages, Levels, ParentPage);
        }
        else
        {
            if (jsonNav.NavConfigs.ContainsKey(ConfigName) == false)
            {
                Start = Navigator.Start(MenuPages, Levels, ParentPage);
            }
            else
            {
                var navConfig = jsonNav.NavConfigs[ConfigName];

                if (ParentPage == null && navConfig.ParentPage != null)
                    ParentPage = navConfig.ParentPage;
                else if (ParentPage == null && navConfig.ParentPage != null)
                    ParentPage = "*";

                if(Variation == null && navConfig.Variation != null)
                    Variation = navConfig.Variation;
                        
                if (Levels == 0 && navConfig.Levels != null)
                    Levels = (int)navConfig.Levels;

                Start = Navigator.Start(MenuPages, Levels, ParentPage);
            }
        }
    }
}