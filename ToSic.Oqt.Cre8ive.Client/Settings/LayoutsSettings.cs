namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class LayoutsSettings
{
    ///// <summary>
    ///// Version number when loading from JSON to verify it's what we expect
    ///// </summary>
    //public float Version { get; set; }

    /// <summary>
    /// Source of these settings / where they came from, to ensure that we can see in debug where a value was picked up from
    /// </summary>
    public string Source { get; set; } = "Unknown";

    public NamedSettings<LayoutSettings> Layouts { get; set; } = new();

    public NamedSettings<ContainerDesignSettings> ContainerDesigns { get; set; } = new();

    public NamedSettings<LanguagesSettings> Languages { get; set; } = new();

    public NamedSettings<LanguageDesignSettings> LanguageDesigns { get; set; } = new();

    public NamedSettings<BreadcrumbSettings> Breadcrumbs { get; set; } = new();

    /// <summary>
    /// The menu definitions
    /// </summary>
    public NamedSettings<MenuConfig> Menus { get; set; } = new();

    /// <summary>
    /// Design definitions of the menu
    /// </summary>
    public NamedSettings<MenuDesignSettings> MenuDesigns { get; set; } = new();
}