namespace ToSic.Oqt.Cre8Magic.Client.Services;

public interface IMagicThemeJsService
{
    Task Log(params object[] args);

    /// <summary>
    /// Set body classes (removes all previous classes in the process)
    /// </summary>
    /// <param name="classes"></param>
    /// <returns></returns>
    Task SetBodyClasses(string classes);
}