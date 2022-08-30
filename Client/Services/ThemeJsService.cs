using System.Threading.Tasks;
using Microsoft.JSInterop;
using ToSic.Oqt.Themes.ToShineBs5.Client.Internal.JsModules;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services;

/// <summary>
/// Constants and helpers related to JS calls from the Theme to it's own JS libraries
/// </summary>
public class ThemeJsService : JsModuleServiceBase
{
    public static string PageControlModulePath = $"./{Defaults.ThemePath}/interop/page-control.js";

    public ThemeJsService(IJSRuntime jsRuntime) : base(jsRuntime, PageControlModulePath)
    {
    }

    private async Task ResetBodyClasses() => await InvokeAsync<string>("clearBodyClasses");

    public async Task SetBodyClasses(string classes)
    {
        await ResetBodyClasses();
        await InvokeAsync<string>("setBodyClass", classes);
    }
}