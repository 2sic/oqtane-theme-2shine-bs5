using System.Threading.Tasks;
using Microsoft.JSInterop;
using ToSic.Oqt.Cre8ive.Client.JsModules;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services;

/// <summary>
/// Constants and helpers related to JS calls from the Theme to it's own JS libraries
/// </summary>
// TODO: SOME DAY move to Cre8ive, as soon as we know how to reliably include the js-assets in the final distribution
public class ThemeJsService : JsModuleServiceBase
{

    public ThemeJsService(IJSRuntime jsRuntime) : base(jsRuntime, $"./{ThemeInfo.ThemePath}/interop/page-control.js")
    {
    }

    private async Task ResetBodyClasses() => await InvokeAsync<string>("clearBodyClasses");

    public async Task SetBodyClasses(string classes)
    {
        await ResetBodyClasses();
        await InvokeAsync<string>("setBodyClass", classes);
    }
}