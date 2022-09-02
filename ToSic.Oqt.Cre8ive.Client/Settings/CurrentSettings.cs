namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class CurrentSettings
{
    public CurrentSettings(LayoutSettings layout, BreadcrumbSettings breadcrumb)
    {
        Layout = layout;
        Breadcrumb = breadcrumb;
    }

    public LayoutSettings Layout { get; set; }

    public BreadcrumbSettings Breadcrumb { get; set; }
}