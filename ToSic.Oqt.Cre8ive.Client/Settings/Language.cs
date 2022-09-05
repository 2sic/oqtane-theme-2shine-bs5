using System.Globalization;

namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class Language
{
    /// <summary>
    /// Empty constructor for deserialization
    /// </summary>
    public Language() { }

    public Language(string culture, string? label = null, string? description = null)
    {
        Culture = culture;
        Label = label;
        Description = description;
    }

    public string? Culture { get; set; }
    public string? Label { get; set; }
    public string? Description { get; set; }

    public bool IsActive => CultureInfo.CurrentUICulture.Name == Culture;

    // TODO: MAYBE additional options to only enable on certain roles...?

}