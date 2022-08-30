using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Internal.JsModules;

/// <summary>
/// Base for any JS Module Helper class
/// </summary>
public abstract class JsModuleServiceBase
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="jsRuntime">JS Runtime of the control, usually available later, like in the OnAfterRenderAsync</param>
    /// <param name="modulePath">Path to the javascript file, must be a JS6 Module</param>
    protected JsModuleServiceBase(IJSRuntime jsRuntime, string modulePath)
    {
        JsRuntime = jsRuntime;
        ModulePath = modulePath;
    }

    protected IJSRuntime JsRuntime { get; }
    protected string ModulePath { get; }

    /// <summary>
    /// The JsObjectReference to the real module.
    /// Will need to load it on first access, so it's async. 
    /// </summary>
    /// <returns></returns>
    public async Task<IJSObjectReference> Module() => _jsModule
        ??= await JsRuntime.InvokeAsync<IJSObjectReference>("import", ModulePath);
    private IJSObjectReference _jsModule;

    protected async Task<TValue> InvokeAsync<TValue>(string identifier)
        => await (await Module()).InvokeAsync<TValue>(identifier);

    protected async Task<TValue> InvokeAsync<TValue>(string identifier, params object[] args)
        => await (await Module()).InvokeAsync<TValue>(identifier, args);
}