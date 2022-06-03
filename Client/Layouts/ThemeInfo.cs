using Oqtane.Models;
using Oqtane.Themes;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Layouts;

public class ThemeInfo : ITheme
{
    public string Fake => typeof(ThemeSettings.ThemeSettings).AssemblyQualifiedName;
    public Theme Theme => new()
    {
        Name = "ToSic.Oqt.Themes.ToShineBs5 Theme with Bootstrap 5",
        Version = "1.0.0",
        ThemeSettingsType = Fake,
        ContainerSettingsType = "Oqtane.Theme.ToSic.ContainerSettings, Oqtane.Theme.ToSic.Oqtane",
        PackageName = "ToSic.Oqt.Themes.ToShineBs5"
    };
}
