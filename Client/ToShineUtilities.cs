using Oqtane.Security;
using Oqtane.Shared;
using Oqtane.UI;

namespace ToSic.Oqt.Themes.ToShineBs5.Client;

public static class ToShineUtilities
{
  public static string ImageUrl(string filename){
    var ns = typeof(ToShineUtilities).Namespace.Replace(".Client", "");
    return "Themes/" + ns + "/Assets/" + filename;
  }

  internal static bool UserIsEditor(PageState pageState)
      => pageState.User != null && UserSecurity.IsAuthorized(pageState.User, PermissionNames.Edit, pageState.Page.Permissions);

  internal static bool UserIsRegistered(PageState pageState)
      => pageState.User != null && UserSecurity.IsAuthorized(pageState.User, RoleNames.Registered);
}

