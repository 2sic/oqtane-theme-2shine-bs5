﻿using ToSic.Oqt.Cre8ive.Client.Styling;

namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class LanguageDesignSettings: SettingsWithStyling<StylingWithActive>
{
    internal string Classes(string tag, Language? lang = null)
    {
        if (!tag.HasValue()) return "";
        if (Styling == null || !Styling.Any()) return "";
        var styles = Styling.FindInvariant(tag);
        if (styles is null) return "";
        return styles.Classes + " " + (lang?.IsActive ?? false ? styles.Active : styles.ActiveFalse);
    }

    public static LanguageDesignSettings Defaults = new()
    {
        Styling = new()
        {
            { "ul", new() { Classes = $"to-shine-page-language {ThemeCssSettings.SettingFromDefaults}" } },
            { "li", new() { Active = $"active {ThemeCssSettings.SettingFromDefaults}", ActiveFalse = "" } }
        }
    };
}