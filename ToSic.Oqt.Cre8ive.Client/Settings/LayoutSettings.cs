namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class LayoutSettings
{
    public string? Logo { get; set; }
    public bool LanguageMenuShow { get; set; } = true;
    public int LanguageMenuShowMin { get; set; } = 0;

    public string? LanguageMenuDesign { get; set; }

    /// <summary>
    /// Name of the breadcrumbs configuration to use.
    /// Will usually be empty, as we'll use the Default instead
    /// </summary>
    public string? Breadcrumbs { get; set; }

    public static LayoutSettings Defaults = new()
    {
        Logo = "unknown-logo.png",
        LanguageMenuShow = true,
        LanguageMenuShowMin = 2,
        Breadcrumbs = Constants.Inherit,
        LanguageMenuDesign = Constants.Inherit,
    };
}