namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class SettingsLanguage
{
    /// <summary>
    /// Empty constructor for deserialization
    /// </summary>
    public SettingsLanguage() { }

    public SettingsLanguage(string culture, string? label = null, string? description = null)
    {
        Culture = culture;
        Label = label;
        Description = description;
    }

    public string? Culture { get; set; }
    public string? Label { get; set; }
    public string? Description { get; set; }

    // TODO: MAYBE additional options to only enable on certain roles...?

}