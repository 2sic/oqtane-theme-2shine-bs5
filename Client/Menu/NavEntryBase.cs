using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Oqtane.Themes.Controls;
using ToSic.Oqt.Themes.ToShineBs5.Client.Navigator;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu
{
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
        public string JsonConfigName { get; set; }

        protected PageNavigator Start { get; private set; }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            string fileName = "wwwroot/Themes/ToSic.Oqt.Themes.ToShineBs5/navigation-settings.json";

            string jsonString = System.IO.File.ReadAllText(fileName);
            JsonNav jsonNav = System.Text.Json.JsonSerializer.Deserialize<JsonNav>(jsonString)!;

            if (jsonNav.NavConfigs.ContainsKey(JsonConfigName) == false)
            {
                Start = Navigator.Start(MenuPages, Levels, ParentPage);
            }
            else
            {
                var navConfig = jsonNav.NavConfigs[JsonConfigName];
                Start = Navigator.Start(MenuPages, (int)navConfig.Levels, navConfig.ParentPage);
            }
        }
    }
}