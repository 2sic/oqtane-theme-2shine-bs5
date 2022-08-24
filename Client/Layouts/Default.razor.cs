using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Oqtane.Models;
using Oqtane.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using static ToSic.Oqt.Themes.ToShineBs5.Client.CssConstants;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Layouts;

public partial class Default : Oqtane.Themes.ThemeBase
{
    // Name to show in the Theme-picker
    public override string Name => "Default";

    // ClassName is used to set the body class which sets the css for this specific layout
    protected virtual string ClassName => "default";

    // Determines if we should show a Nav on the side of the layout in addition to top
    protected virtual bool ShowSidebarNavigation => false;

    // Show a breadcrumb on top?
    protected virtual bool ShowBreadcrumb => true;

    public override List<Resource> Resources => new()
    {
        // Bootstrap with our customizations (generated with Sass using Webpack)
        new Resource { ResourceType = ResourceType.Stylesheet, Url = ThemeAssetsPath + "theme.min.css" },
        // Bootstrap JS
        new Resource { ResourceType = ResourceType.Script, Url = ThemeAssetsPath + "bootstrap.bundle.min.js" },
        // Theme JS for page classes, Up-button etc.
        new Resource { ResourceType = ResourceType.Script, Url = ThemeAssetsPath + "ambient.js" },
    };

    public const string PaneNameHeader = "Header";
    public const string PaneNameContent = "Content";
    public override string Panes => string.Join(",", PaneNames.Admin, PaneNameHeader, PaneNameContent);

    // TODO: Create helper method that gets this from current namespace...
    public const string ThemeAssetsPath = "Themes/ToSic.Oqt.Themes.ToShineBs5/";

    [Inject] protected PageCssClasses PageCssClasses { get; set; }




    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        var bodyClasses = await PageCssClasses.DetermineBodyClasses(PageState.Page, ClassName);

        _bodyClassJs ??= await JSRuntime.InvokeAsync<IJSObjectReference>("import", Path.Combine("./", ThemeAssetsPath, "interop/page-control.js"));
        // TODO: create constants for the JS names in our libs
        await _bodyClassJs.InvokeAsync<string>("clearBodyClasses");
        await _bodyClassJs.InvokeAsync<string>("setBodyClass", bodyClasses);
    }
    private IJSObjectReference _bodyClassJs;

    /// <summary>
    /// Special classes for the header pane, especially to indicate when it's empty
    /// </summary>
    private string HeaderPaneClasses() => PageCssClasses.PaneIsEmpty(PageState, PaneNameHeader)
        // TODO: CHECK IF this class must contain the name "header" or if pane-empty would suffice
        ? $"{LayoutPrefix}header-pane-empty"
        : string.Empty;
}