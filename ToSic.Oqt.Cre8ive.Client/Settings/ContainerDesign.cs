using ToSic.Oqt.Cre8ive.Client.Styling;

namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class ContainerDesign: StylingBase
{
    public string? IsPublished { get; set; }
    public string? IsNotPublished { get; set; }

    public string? IsAdminModule { get; set; }
    public string? IsNotAdminModule { get; set; }

}
