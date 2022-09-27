using System.Threading.Tasks;
using Microsoft.JSInterop;
using ToSic.Cre8Magic.Client.JsModules;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services;

/// <summary>
/// Constants and helpers related to JS calls from the Theme to it's own JS libraries
/// </summary>
// TODO: SOME DAY move to Cre8Magic, as soon as we know how to reliably include the js-assets in the final distribution
public class MagicThemeJsService : MagicJsServiceBase, IMagicThemeJsService
{

    public MagicThemeJsService(IJSRuntime jsRuntime) : base(jsRuntime, $"./{ThemeInfo.ThemePath}/interop/page-control.js")
    {
    }

    /// <inheritdoc />
    public async Task SetBodyClasses(string classes)
    {
        await InvokeAsync<string>("setBodyClass", classes);
    }
}