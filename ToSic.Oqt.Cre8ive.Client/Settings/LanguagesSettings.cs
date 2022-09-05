using System.Collections.Generic;
using ToSic.Oqt.Cre8ive.Client.Styling;
using static System.StringComparer;

namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class LanguagesSettings
{
    /// <summary>
    /// If true, will only show the languages which are explicitly configured.
    /// If false, will first show the configured languages, then the rest. 
    /// </summary>
    public bool HideOthers { get; set; } = false;

    /// <summary>
    /// List of languages
    /// </summary>
    public Dictionary<string, Language>? List
    {
        get => _list;
        set => _list = InitList(value);
    }
    private Dictionary<string, Language>? _list;

    internal string Classes(string tag, Language? lang = null)
    {
        if (!tag.HasValue()) return "";
        var styles = Styling.FindInvariant(tag);
        if (styles is null) return "";
        return styles is StylingWithActive swa
            ? styles.Classes + " " + ((lang?.IsActive ?? false) ? swa.Active : swa.ActiveFalse)
            : styles.Classes ?? "";
    }

    private Dictionary<string, Language>? InitList(Dictionary<string, Language>? dic)
    {
        if (dic == null) return null;
        // Ensure each config knows what culture it's for, as 
        foreach (var set in dic)
            set.Value.Culture ??= set.Key;
        return dic.ToInvariant();
    }

    public Dictionary<string, StylingBase> Styling
    {
        get => _styling;
        set => _styling = value.ToInvariant();
    }
    private Dictionary<string, StylingBase> _styling = new(InvariantCultureIgnoreCase);

    public static LanguagesSettings Defaults = new()
    {
        HideOthers = false,
        List = new()
        {
            { "en", new() { Culture = "en", Description = "English" } }
        },
        Styling = new()
        {
            { "ul", new() { Classes = "to-shine-page-language" } },
            { "li", new StylingWithActive { Active = "active", ActiveFalse = "" } }
        }
    };

}