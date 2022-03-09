using Oqtane.Models;
using Oqtane.Themes;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Fullscreen
{
    public class ThemeInfo : ITheme
    {
        public Theme Theme => new Theme
        {
            Name = "2shine Oqtane theme with Bootstrap 5 - Fullscreen",
            Version = "1.0.0",
            ContainerSettingsType = "Oqtane.Theme.tosic.toshine.ContainerSettings, Oqtane.Theme.tosic.toshine.Oqtane",
            PackageName = "ToSic.Oqt.Themes.ToShineBs5.Fullscreen"
        };

    }
}
