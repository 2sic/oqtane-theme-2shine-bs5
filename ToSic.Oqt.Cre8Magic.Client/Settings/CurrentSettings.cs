using ToSic.Oqt.Cre8Magic.Client.Styling;
using static System.StringComparer;

namespace ToSic.Oqt.Cre8Magic.Client.Settings;

public class CurrentSettings
{
    public CurrentSettings(
        string name,
        MagicSettingsService service,
        LayoutSettings layout, 
        BreadcrumbSettings breadcrumb, 
        PageStyling page, 
        LanguagesSettings languages, 
        MagicLanguageDesignSettings languageDesign, 
        MagicContainerDesignSettings containerDesign)
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

    public MagicSettingsService Service { get; }

    public LayoutSettings Layout { get; }

    public BreadcrumbSettings Breadcrumb { get; }

    public PageStyling Page { get; }

    public LanguagesSettings Languages { get; }

    public MagicLanguageDesignSettings LanguageDesign { get; set; }

    public MagicContainerDesignSettings ContainerDesign { get; set; }

    public Dictionary<string, string> DebugSources { get; } = new(InvariantCultureIgnoreCase);
}