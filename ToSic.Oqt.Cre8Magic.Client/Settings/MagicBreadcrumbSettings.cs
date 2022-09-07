namespace ToSic.Oqt.Cre8Magic.Client.Settings;

public class MagicBreadcrumbSettings
{
    public string? Separator { get; set; }
    private const string BreadcrumbSeparatorDefault = "&nbsp;&rsaquo;&nbsp;";

    public string? Revealer { get; set; }

    private const string BreadcrumbRevealDefault = "…"; // Ellipsis character

    public static MagicBreadcrumbSettings Defaults = new()
    {
        Separator = BreadcrumbSeparatorDefault,
        Revealer = BreadcrumbRevealDefault,
    };

}