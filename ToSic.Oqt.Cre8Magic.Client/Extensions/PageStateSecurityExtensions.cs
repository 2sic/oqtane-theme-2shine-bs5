using Oqtane.Models;
using Oqtane.Security;
using Oqtane.Shared;
using Oqtane.UI;

namespace ToSic.Oqt.Cre8Magic.Client;

public static class PageStateSecurityExtensions
{
    public static bool UserIsEditor(this PageState pageState)
        => pageState.User != null && UserSecurity.IsAuthorized(pageState.User, PermissionNames.Edit, pageState.Page.Permissions);

    public static bool UserIsAdmin(this PageState pageState)
        => pageState.User != null && UserSecurity.IsAuthorized(pageState.User, PermissionNames.Edit, pageState.Page.Permissions);

    public static bool UserIsRegistered(this PageState pageState)
        => pageState.User != null && UserSecurity.IsAuthorized(pageState.User, RoleNames.Registered);

    /// <summary>
    /// Modules are treated as admin modules (and must use the the admin container) if they are marked as such, or come from the Oqtane ....Admin... type
    /// </summary>
    /// <param name="module"></param>
    /// <returns></returns>
    public static bool ForceAdminContainer(this Module module) 
        => module.UseAdminContainer || module.ModuleType.Contains(".Admin.");

    public static bool IsPublished(this Module module)
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
            ?.Permissions
            .Split(';')
            .Contains(roleName)
            ?? false;
    }

}