namespace ToSic.Oqt.Cre8Magic.Client.Services;

public abstract class MagicServiceWithSettingsBase
{
    public void InitSettings(CurrentSettings settings) => Settings ??= settings;

    public CurrentSettings? Settings { get; private set; }

}