namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class LayoutSettings
{
    public string? Logo { get; set; }
    public bool LanguageMenuShow { get; set; } = true;
    public int LanguageMenuShowMin { get; set; } = 0;

    public string? BreadcrumbSeparator { get; set; }
    public const string BreadcrumbSeparatorDefault = "&nbsp;&rsaquo;&nbsp;";

    public string? BreadcrumbReveal { get; set; }

    public const string BreadcrumbRevealDefault = "…"; // Ellipsis character
}