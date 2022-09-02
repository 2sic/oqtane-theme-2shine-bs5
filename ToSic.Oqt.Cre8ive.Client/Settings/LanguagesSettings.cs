﻿namespace ToSic.Oqt.Cre8ive.Client.Settings;

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

    private Dictionary<string, Language>? InitList(Dictionary<string, Language>? dic)
    {
        if (dic == null) return null;
        // Ensure each config knows what culture it's for, as 
        foreach (var set in dic) 
            set.Value.Culture ??= set.Key;
        return new Dictionary<string, Language>(dic, StringComparer.InvariantCultureIgnoreCase);
    }

    public static LanguagesSettings Defaults = new()
    {
        HideOthers = false,
        List = new()
        {
            { "en", new Language("en", "English") }
        }
    };

}