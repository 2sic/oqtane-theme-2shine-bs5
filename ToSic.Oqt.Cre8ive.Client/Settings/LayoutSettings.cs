namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class LayoutSettings
{
    /// <summary>
    /// The logo to show, should be located in the assets subfolder
    /// </summary>
    public string? Logo { get; set; }

    /// <summary>
    /// The languages configuration which should be used
    /// </summary>
    public string? Languages { get; set; } = null;

    // TODO:
    // - probably add properties like BreadcrumbShow
    // - consider how to model it - should we have sub-objects? or too complex?

    public bool LanguageMenuShow { get; set; } = true;

    public int LanguageMenuShowMin { get; set; } = 0;

    public string? LanguageMenuDesign { get; set; }

    /// <summary>
    /// The preferred container design to use. 
    /// </summary>
    public string? ContainerDesign { get; set; }

    /// <summary>
    /// Map of menu names and alternate configurations to load instead
    /// </summary>
    public NamedSettings<string> Menus { get; set; } = new();

    /// <summary>
    /// Name of the breadcrumbs configuration to use.
    /// Will usually be empty, as we'll use the Default instead
    /// </summary>
    public string? Breadcrumbs { get; set; }

    public static LayoutSettings Defaults = new()
    {
        Logo = "unknown-logo.png",
        ContainerDesign = Constants.Inherit,
        Languages = Constants.Inherit,
        LanguageMenuDesign = Constants.Inherit,
        LanguageMenuShow = true,
        LanguageMenuShowMin = 2,
        Breadcrumbs = Constants.Inherit,
        // The menus-map. Since this is the fallback, it must have at least an entry to not be skipped. 
        Menus = new()
        {
            { Constants.Default, Constants.Default }
        },
    };
}