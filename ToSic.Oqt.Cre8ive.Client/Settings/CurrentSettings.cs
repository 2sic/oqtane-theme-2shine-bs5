using static System.StringComparer;

namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class CurrentSettings
{
    public CurrentSettings(LayoutSettings layout, BreadcrumbSettings breadcrumb, ThemeCssSettings css, LanguagesSettings languages)
    {
        Layout = layout;
        Breadcrumb = breadcrumb;
        Css = css;
        Languages = languages;
    }

    public LayoutSettings Layout { get; }

    public BreadcrumbSettings Breadcrumb { get; }

    public ThemeCssSettings Css { get; }

    public LanguagesSettings Languages { get; }

    public Dictionary<string, string> DebugSources { get; } = new(InvariantCultureIgnoreCase);
}