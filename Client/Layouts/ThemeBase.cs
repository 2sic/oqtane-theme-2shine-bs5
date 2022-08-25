using Microsoft.AspNetCore.Components;
using Oqtane.Models;
using Oqtane.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Layouts;

/// <summary>
/// Base class for our themes. It's responsible for
///
/// 1. Some basic properties such as Name, BodyClasses etc. which each theme can configure
/// 2. Adding special classes to the body tag so that the CSS can best optimize for each scenario
/// </summary>
/// <remarks>
/// - The base class must be abstract, so that Oqtane doesn't see it as a real them.
/// - The config-properties must be abstract, so the inheriting files are forced to set them. 
/// </remarks>
public abstract class ThemeBase : Oqtane.Themes.ThemeBase
{
    /// <summary>
    /// Name to show in the Theme-picker.
    /// Must be set by each inheriting theme. 
    /// </summary>
    public abstract override string Name { get; }

    /// <summary>
    /// Sets additional body classes - usually to activate CSS variations for this theme
    /// </summary>
    protected abstract string BodyClasses { get; }

    /// <summary>
    /// Determines if we should show a Nav on the side of the layout in addition to top
    /// </summary>
    protected abstract bool ShowSidebarNavigation { get; }

    /// <summary>
    /// Show a breadcrumb on top?
    /// </summary>
    protected abstract bool ShowBreadcrumb { get; }

    public override List<Resource> Resources => new()
    {
        // Bootstrap with our customizations (generated with Sass using Webpack)
        new Resource { ResourceType = ResourceType.Stylesheet, Url = ThemeCss.AssetsPath + "theme.min.css" },
        // Bootstrap JS
        new Resource { ResourceType = ResourceType.Script, Url = ThemeJs.AssetsPath + "bootstrap.bundle.min.js" },
        // Theme JS for page classes, Up-button etc.
        new Resource { ResourceType = ResourceType.Script, Url = ThemeJs.AssetsPath + "ambient.js" },
    };

    public const string PaneNameHeader = "Header";
    public const string PaneNameContent = "Content";
    public override string Panes => string.Join(",", PaneNames.Admin, PaneNameHeader, PaneNameContent);

    [Inject] protected PageCss PageCss { get; set; }


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        _themeJs ??= new ThemeJs(JSRuntime);
        var bodyClasses = await PageCss.BodyClasses(PageState.Page, BodyClasses);
        await _themeJs.SetBodyClasses(bodyClasses);
    }
    private ThemeJs _themeJs;

    /// <summary>
    /// Special classes for divs surrounding panes pane, especially to indicate when it's empty
    /// </summary>
    public string PaneClasses(string paneName) => PageCss.PaneIsEmpty(PageState, paneName);
}