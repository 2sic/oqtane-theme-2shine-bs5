using ToSic.Oqt.Cre8ive.Client.Styling;

namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class LanguageDesign: SettingsWithStyling<StylingWithActive>
{
    internal string Classes(string tag, Language? lang = null)
    {
        if (!tag.HasValue()) return "";
        if (Styling == null || !Styling.Any()) return "";
        var styles = Styling.FindInvariant(tag);
        if (styles is null) return "";
        return styles.Classes + " " + (lang?.IsActive ?? false ? styles.IsActive : styles.IsNotActive);
    }

    public static LanguageDesign Defaults = new()
    {
        Styling = new()
        {
            { "ul", new() { Classes = $"to-shine-page-language {PageStyling.SettingFromDefaults}" } },
            { "li", new() { IsActive = $"active {PageStyling.SettingFromDefaults}", IsNotActive = "" } }
        }
    };
}