using ToSic.Oqt.Themes.ToShineBs5.Client.Models;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services
{
    public class MenuConfigFromJsonService
    {
        public MenuConfigCatalog JsonConfig => _menuConfigCatalog ??= LoadJson();
        private MenuConfigCatalog _menuConfigCatalog;

        private MenuConfigCatalog LoadJson()
        {
            var jsonFileName = $"{Defaults.WwwRoot}/{AssetUrls.ThemePath}/{Defaults.NavigationJsonFile}";
            try
            {
                var jsonString = System.IO.File.ReadAllText(jsonFileName);
                var result = System.Text.Json.JsonSerializer.Deserialize<MenuConfigCatalog>(jsonString)!;

                return result;
            }
            catch
            {
                throw;//wip
                // probably no json file found?
                return new MenuConfigCatalog();
            }
        }

    }
}
