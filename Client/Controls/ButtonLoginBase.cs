using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Oqtane;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Controls
{
    public class ButtonLoginBase: Oqtane.Themes.Controls.LoginBase
    {
        [Inject] private IStringLocalizer<SharedResources> Localizer { get; set; }

        protected bool IsLoggedIn => _isLoggedIn ??= PageState.User is { IsAuthenticated: true };
        private bool? _isLoggedIn;

        protected string LocalizedLabel => Localizer[IsLoggedIn ? "Logout" : "Login"];

        protected async Task ChangeLogin()
        {
            if (IsLoggedIn)
                await LogoutUser();
            else
                LoginUser();
        }
    }
}
