using ToSic.Oqt.Cre8Magic.Client.Styling;
using static System.StringComparer;

namespace ToSic.Oqt.Cre8Magic.Client.Settings;

/// <summary>
/// The current settings of a page.
/// </summary>
public class MagicSettings
{
    public MagicSettings(
        string name,
        MagicSettingsService service,
        MagicLayoutSettings layout, 
        MagicBreadcrumbSettings breadcrumb, 
        MagicPageDesign page, 
        MagicLanguagesSettings languages, 
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

    public MagicLayoutSettings Layout { get; }

    public MagicBreadcrumbSettings Breadcrumb { get; }

    public MagicPageDesign Page { get; }

    public MagicLanguagesSettings Languages { get; }

    public MagicLanguageDesignSettings LanguageDesign { get; set; }

    public MagicContainerDesignSettings ContainerDesign { get; set; }

    public Dictionary<string, string> DebugSources { get; } = new(InvariantCultureIgnoreCase);
}