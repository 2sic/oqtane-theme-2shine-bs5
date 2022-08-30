using ToSic.Oqt.Themes.ToShineBs5.Client.Layouts;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Internal.Utilities;

public static class AssetUrls
{
    public static string ImageUrl(string filename) 
        => ThemePath + "/Assets/" + filename;

    public static string ThemePath => "Themes/" + RootNamespace;

    public static string RootNamespace => _rootNamespace
                                          ??= new ThemeInfo().Theme.PackageName; // typeof(ThemeInfo).Namespace.Replace(".Client.Layouts", "");
    private static string _rootNamespace;
}

