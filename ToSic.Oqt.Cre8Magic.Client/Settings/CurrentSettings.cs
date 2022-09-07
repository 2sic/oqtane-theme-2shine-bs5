using ToSic.Oqt.Cre8ive.Client.Styling;
using static System.StringComparer;

namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class CurrentSettings
{
    public CurrentSettings(
        string name,
        ThemeSettingsService service,
        LayoutSettings layout, 
        BreadcrumbSettings breadcrumb, 
        PageStyling page, 
        LanguagesSettings languages, 
        LanguageDesign languageDesign, 
        ContainerDesign containerDesign)
    {
        Layout = layout;
        Breadcrumb = breadcrumb;
        Page = page;
        Languages = languages;
        LanguageDesign = languageDesign;
        ContainerDesign = containerDesign;
        Name = name;
        Service = service;
    }

    public string MagicContext { get; set; } = "";

    public string Name { get; }

    public ThemeSettingsService Service { get; }

    public LayoutSettings Layout { get; }

    public BreadcrumbSettings Breadcrumb { get; }

    public PageStyling Page { get; }

    public LanguagesSettings Languages { get; }

    public LanguageDesign LanguageDesign { get; set; }

    public ContainerDesign ContainerDesign { get; set; }

    public Dictionary<string, string> DebugSources { get; } = new(InvariantCultureIgnoreCase);
}