using Oqtane.Models;
using Oqtane.Themes;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.CenteredSubmenu
{
    public class CenteredSubmenuThemeInfo : ITheme
    {
        public Theme Theme => new Theme
        {
            Name = "2shine Oqtane theme with Bootstrap 5 - Centered-Submenu",
            Version = "1.0.0",
            ContainerSettingsType = "Oqtane.Theme.tosic.ContainerSettings, Oqtane.Theme.tosic.Oqtane",
            PackageName = "ToSic.Oqt.Themes.ToShineBs5"
        };

    }
}
