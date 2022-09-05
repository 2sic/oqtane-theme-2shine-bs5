namespace ToSic.Oqt.Cre8ive.Client.Services;

public abstract class ServiceWithCurrentSettings
{
    public void InitSettings(CurrentSettings settings) => Settings ??= settings;

    public CurrentSettings? Settings { get; private set; }

}