namespace ToSic.Oqt.Cre8Magic.Client.Styling;

public class MagicDesignWithActive: MagicDesignBase
{
    /// <summary>
    /// These classes are applied if something (a page, language) is the active one. 
    /// </summary>
    public string? IsActive { get; set; }

    /// <summary>
    /// These classes are applied if something is not active (so another language/page is active).
    /// Rarely used. 
    /// </summary>
    public string? IsNotActive { get; set; }

}