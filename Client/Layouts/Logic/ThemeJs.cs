using System.Threading.Tasks;
using Microsoft.JSInterop;
using ToSic.Oqt.Themes.ToShineBs5.Client.Utilities;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Layouts;

/// <summary>
/// Constants and helpers related to JS calls from the Theme to it's own JS libraries
/// </summary>
internal class ThemeJs : JsModuleBase
{
    public const string AssetsPath = "Themes/ToSic.Oqt.Themes.ToShineBs5/";
    public const string PageControlModulePath = $"./{AssetsPath}interop/page-control.js";

    public ThemeJs(IJSRuntime jsRuntime) : base(jsRuntime, PageControlModulePath)
    {
    }

    public async Task ResetBodyClasses() => await InvokeAsync<string>("clearBodyClasses");

    public async Task SetBodyClasses(string classes)
    {
        await ResetBodyClasses();
        await InvokeAsync<string>("setBodyClass", classes);
    }
}