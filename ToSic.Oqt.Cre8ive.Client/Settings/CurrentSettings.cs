using ToSic.Oqt.Cre8ive.Client.Styling;
using static System.StringComparer;

namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class CurrentSettings
{
    public CurrentSettings(
        ThemeSettingsService service, 
        LayoutSettings layout, 
        BreadcrumbSettings breadcrumb, 
        PageStyling css, 
        LanguagesSettings languages, 
        LanguageDesignSettings languageDesign, 
        ContainerDesignSettings containerDesign
    )
    {
        Layout = layout;
        Breadcrumb = breadcrumb;
        Css = css;
        Languages = languages;
        LanguageDesign = languageDesign;
        ContainerDesign = containerDesign;
        Service = service;
    }

    public ThemeSettingsService Service { get; }

    public LayoutSettings Layout { get; }

    public BreadcrumbSettings Breadcrumb { get; }

    public PageStyling Css { get; }

    public LanguagesSettings Languages { get; }

    public LanguageDesignSettings LanguageDesign { get; set; }

    public ContainerDesignSettings ContainerDesign { get; set; }

    public Dictionary<string, string> DebugSources { get; } = new(InvariantCultureIgnoreCase);
}