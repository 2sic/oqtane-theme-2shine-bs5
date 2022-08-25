namespace ToSic.Oqt.Themes.ToShineBs5.Client;

public static class ToShineUtilities
{
  public static string ImageUrl(string filename){
    var ns = typeof(ToShineUtilities).Namespace.Replace(".Client", "");
    return "Themes/" + ns + "/Assets/" + filename;
  }
}

