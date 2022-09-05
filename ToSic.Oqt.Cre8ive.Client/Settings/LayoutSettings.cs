namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class LayoutSettings
{
    public string? Logo { get; set; }

    public string? Languages { get; set; } = null;

    public bool LanguageMenuShow { get; set; } = true;

    public int LanguageMenuShowMin { get; set; } = 0;

    public string? LanguageMenuDesign { get; set; }

    public string? ContainerDesign { get; set; }

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
        Menus = new() // no map for the menus
        {
            { Constants.Default, Constants.Default }
        },
    };
}