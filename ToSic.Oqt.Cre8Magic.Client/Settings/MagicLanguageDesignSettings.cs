using ToSic.Oqt.Cre8Magic.Client.Styling;
using static ToSic.Oqt.Cre8Magic.Client.Styling.MagicPageDesign;

namespace ToSic.Oqt.Cre8Magic.Client.Settings;

public class MagicLanguageDesignSettings: NamedSettings<MagicDesignWithActive>
{
    internal string Classes(string tag, MagicLanguage? lang = null)
    {
        if (!tag.HasValue()) return "";
        if (/*Design == null ||*/ !this.Any()) return "";
        var styles = this.FindInvariant(tag);
        if (styles is null) return "";
        return styles.Classes + " " + (lang?.IsActive ?? false ? styles.IsActive : styles.IsNotActive);
    }

    public static MagicLanguageDesignSettings Defaults = new()
    {
        { "ul", new() { Classes = $"{MainPrefix}page-language {SettingFromDefaults}" } },
        { "li", new() { IsActive = $"active {SettingFromDefaults}", IsNotActive = "" } }
    };
}