using System.Linq;
using Oqtane.Models;
using Oqtane.Security;
using Oqtane.Shared;
using Oqtane.UI;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Utilities;

public static class PageStateSecurityExtensions
{
    internal static bool UserIsEditor(this PageState pageState)
        => pageState.User != null && UserSecurity.IsAuthorized(pageState.User, PermissionNames.Edit, pageState.Page.Permissions);

    internal static bool UserIsRegistered(this PageState pageState)
        => pageState.User != null && UserSecurity.IsAuthorized(pageState.User, RoleNames.Registered);

    internal static bool IsPublished(this Module module)
        => /*UserSecurity.*/ContainsRole(module.Permissions, PermissionNames.View, RoleNames.Everyone);


    /// <summary>
    /// Temporary copy of UserSecurity.ContainsRole, which only exists in Oqtane 3.2
    /// Remove as soon as the theme supports only that version
    /// </summary>
    /// <param name="permissionStrings"></param>
    /// <param name="permissionName"></param>
    /// <param name="roleName"></param>
    /// <returns></returns>
    private static bool ContainsRole(string permissionStrings, string permissionName, string roleName)
    {
        return UserSecurity.GetPermissionStrings(permissionStrings)
            .FirstOrDefault(item => item.PermissionName == permissionName)
            .Permissions.Split(';').Contains(roleName);
    }

}