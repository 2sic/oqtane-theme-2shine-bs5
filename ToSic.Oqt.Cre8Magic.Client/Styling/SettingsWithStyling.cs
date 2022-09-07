namespace ToSic.Oqt.Cre8Magic.Client.Styling;

public class SettingsWithStyling<T> where T : class
{
    public NamedSettings<T>? Styling { get; set; } = new();
}