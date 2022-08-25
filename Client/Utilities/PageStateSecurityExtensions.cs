using Oqtane.Security;
using Oqtane.Shared;
using Oqtane.UI;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Utilities
{
    public static class PageStateSecurityExtensions
    {
        internal static bool UserIsEditor(this PageState pageState)
            => pageState.User != null && UserSecurity.IsAuthorized(pageState.User, PermissionNames.Edit, pageState.Page.Permissions);

        internal static bool UserIsRegistered(this PageState pageState)
            => pageState.User != null && UserSecurity.IsAuthorized(pageState.User, RoleNames.Registered);

    }
}
