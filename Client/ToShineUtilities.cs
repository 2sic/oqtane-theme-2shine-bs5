namespace ToSic.Oqt.Themes.ToShineBs5.Client;
using Oqtane.Shared;
using System;

public static class ToShineUtilities
{
  public static string ImageUrl(string Filename){
    string Namespace = typeof(ToShineUtilities).Namespace.Replace(".Client", "");
    return "Themes/" + Namespace + "/Assets/" + Filename;
  }
}

