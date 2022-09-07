using ToSic.Oqt.Cre8Magic.Client.Styling;

namespace ToSic.Oqt.Cre8Magic.Client.Settings;

/// <summary>
/// This is a catalog of all kinds of configurations.
/// It serves as a kind of database to manage all configurations, which will usually be retrieved using a name. 
/// </summary>
public class MagicSettingsCatalog
{
    ///// <summary>
    ///// Version number when loading from JSON to verify it's what we expect
    ///// </summary>
    //public float Version { get; set; }

    /// <summary>
    /// Source of these settings / where they came from, to ensure that we can see in debug where a value was picked up from
    /// </summary>
    public string Source { get; set; } = "Unknown";

    public NamedSettings<MagicLayoutSettings> Layouts { get; set; } = new();

    public NamedSettings<MagicContainerDesignSettings> ContainerDesigns { get; set; } = new();

    public NamedSettings<MagicLanguagesSettings> Languages { get; set; } = new();

    public NamedSettings<MagicLanguageDesignSettings> LanguageDesigns { get; set; } = new();

    public NamedSettings<MagicBreadcrumbSettings> Breadcrumbs { get; set; } = new();

    // TODO: For completeness, we may need BreadcrumbDesign

    public NamedSettings<MagicPageDesign> PageDesigns { get; set; } = new();

    /// <summary>
    /// The menu definitions
    /// </summary>
    public NamedSettings<MagicMenuSettings> Menus { get; set; } = new();

    /// <summary>
    /// Design definitions of the menu
    /// </summary>
    public NamedSettings<MagicMenuDesignSettings> MenuDesigns { get; set; } = new();
}