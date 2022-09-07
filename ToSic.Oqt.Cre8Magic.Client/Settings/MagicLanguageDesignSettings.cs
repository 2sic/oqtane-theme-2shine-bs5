using ToSic.Oqt.Cre8Magic.Client.Styling;

namespace ToSic.Oqt.Cre8Magic.Client.Settings;

public class MagicLanguageDesignSettings: NamedSettings<MagicDesignWithActive>
{
    internal string Classes(string tag, Language? lang = null)
    {
        if (!tag.HasValue()) return "";
        if (/*Design == null ||*/ !this.Any()) return "";
        var styles = this.FindInvariant(tag);
        if (styles is null) return "";
        return styles.Classes + " " + (lang?.IsActive ?? false ? styles.IsActive : styles.IsNotActive);
    }

    public static MagicLanguageDesignSettings Defaults = new()
    {
        //Design = new()
        //{
            { "ul", new() { Classes = $"to-shine-page-language {MagicPageDesign.SettingFromDefaults}" } },
            { "li", new() { IsActive = $"active {MagicPageDesign.SettingFromDefaults}", IsNotActive = "" } }
        //}
    };
}