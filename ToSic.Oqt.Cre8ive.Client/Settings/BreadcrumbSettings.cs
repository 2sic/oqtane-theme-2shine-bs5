namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class BreadcrumbSettings
{
    public string? Separator { get; set; }
    public const string BreadcrumbSeparatorDefault = "&nbsp;&rsaquo;&nbsp;";

    public string? Revealer { get; set; }

    public const string BreadcrumbRevealDefault = "…"; // Ellipsis character

    public static BreadcrumbSettings Defaults = new()
    {
        Separator = BreadcrumbSeparatorDefault,
        Revealer = BreadcrumbRevealDefault,
    };

}