namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class SettingsWithStyling<T> where T : class
{
    public NamedSettings<T>? Styling { get; set; } = new();
}