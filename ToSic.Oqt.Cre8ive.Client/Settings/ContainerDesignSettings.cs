using Oqtane.Models;
using ToSic.Oqt.Cre8ive.Client.Styling;
using static ToSic.Oqt.Cre8ive.Client.Styling.PageStyling;

namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class ContainerDesignSettings : SettingsWithStyling<ContainerStyling>
{
    internal string Classes(Module module, string tag)
    {
        //if (module == null) return "";
        if (Styling == null || !Styling.Any()) return "";
        var styles = Styling.FindInvariant(tag);
        if (styles is null) return "";
        return string.Join(" ", new[]
        {
            module.IsPublished() ? styles.IsPublished : styles.IsNotPublished, // Info-Class if not published
            module.UseAdminContainer ? styles.IsAdminModule : styles.IsNotAdminModule // Info-class if admin module
        }.Where(s => s.HasValue()));

    }

    public static ContainerDesignSettings Defaults = new()
    {
        Styling = new()
        {
            {
                "div", new()
                {
                    Classes = $"to-shine-page-language {SettingFromDefaults}",
                    IsNotPublished = $"{ModulePrefixDefault}unpublished  {SettingFromDefaults}",
                    IsAdminModule = $"{LayoutPrefixDefault}admin-container  {SettingFromDefaults}"
                }
            },
        }
    };
}