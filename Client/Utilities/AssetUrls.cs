namespace ToSic.Oqt.Themes.ToShineBs5.Client;

public static class AssetUrls
{
    public static string ImageUrl(string filename) 
        => ThemePath + "/Assets/" + filename;

    public static string ThemePath => "Themes/" + RootNamespace;

    public static string RootNamespace => _rootNamespace
                                          ??= typeof(AssetUrls).Namespace.Replace(".Client", "");
    private static string _rootNamespace;
}

