namespace ToSic.Oqt.Cre8Magic.Client.Settings;

public interface IHasSettingsExceptions
{
    public bool HasExceptions => Exceptions?.Any() ?? false;

    List<SettingsException> Exceptions { get; }
}