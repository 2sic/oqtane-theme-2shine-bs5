namespace ToSic.Oqt.Cre8ive.Client.Settings;

public interface IHasSettingsExceptions
{
    public bool HasExceptions => Exceptions?.Any() ?? false;

    List<SettingsException> Exceptions { get; }
}