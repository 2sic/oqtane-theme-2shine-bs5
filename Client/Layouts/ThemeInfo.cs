using Oqtane.Models;
using Oqtane.Themes;
using ToSic.Oqt.Themes.ToShineBs5.Client.ThemeSettings;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Layouts;

/// <summary>
/// The theme-info for registration in Oqtane.
/// </summary>
/// <remarks>
/// Important: It must be in the same namespace '...Layouts' as the layout files by convention,
/// otherwise the Oqtane registration won't work as expected. 
/// </remarks>
public class ThemeInfo : ITheme
{
    public Theme Theme => new()
    {
        Name = "ToShine Bootstrap 5",
        Version = "1.0.0",
        ThemeSettingsType = typeof(Settings).AssemblyQualifiedName,
        //ContainerSettingsType = "Oqtane.Theme.ToSic.ContainerSettings, Oqtane.Theme.ToSic.Oqtane",
        PackageName = "ToSic.Oqt.Themes.ToShineBs5",
    };
}
