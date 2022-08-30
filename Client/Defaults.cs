using ToSic.Oqt.Themes.ToShineBs5.Client.Layouts;

namespace ToSic.Oqt.Themes.ToShineBs5.Client;

/// <summary>
/// Should contain default values for all the scenarios where configurations are missing or not necessary
/// </summary>
public class Defaults
{
    // Todo: move to json
    public const string LanguageList = ""; // "en: Engl, de-ch"; // ""en: EN, de: DE, de-CH: CH, fr: FR"; //", nl-NL: NDL";

    // Todo: move to json
    public const string LogoFile = "logo.svg";

    #region Technical paths

    public const string WwwRoot = "wwwroot";

    public static string ThemePath => "Themes/" + ThemePackageName;

    public static string AssetsPath => ThemePath + "/Assets";

    public static string ThemePackageName => _rootNamespace ??= new ThemeInfo().Theme.PackageName;
    private static string _rootNamespace;

    #endregion

    #region Navigation Constants

    public const string NavigationJsonFile = "navigation.json";

    #endregion


}