﻿using static System.StringComparer;

namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class CurrentSettings
{
    public CurrentSettings(ThemeSettingsService service, LayoutSettings layout, BreadcrumbSettings breadcrumb, ThemeCssSettings css, LanguagesSettings languages, LanguageDesignSettings languageDesign)
    {
        Layout = layout;
        Breadcrumb = breadcrumb;
        Css = css;
        Languages = languages;
        LanguageDesign = languageDesign;
        Service = service;
    }

    public ThemeSettingsService Service { get; }

    public LayoutSettings Layout { get; }

    public BreadcrumbSettings Breadcrumb { get; }

    public ThemeCssSettings Css { get; }

    public LanguagesSettings Languages { get; }

    public LanguageDesignSettings LanguageDesign { get; set; }

    public Dictionary<string, string> DebugSources { get; } = new(InvariantCultureIgnoreCase);
}