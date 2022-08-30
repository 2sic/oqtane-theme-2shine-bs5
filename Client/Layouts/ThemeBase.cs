using Microsoft.AspNetCore.Components;
using Oqtane.Models;
using Oqtane.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using CList = System.Collections.Generic.List<(string Pane, System.Type Type, System.Collections.Generic.Dictionary<string, object> Parameters)>;

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

    /// <summary>
    /// WIP
    /// inspired by http://www.binaryintellect.net/articles/a92dea29-3218-4d1c-a132-9671b518d1f4.aspx
    /// </summary>
    protected CList DynamicComponents { get; } = new();

    public override List<Resource> Resources => new()
    {
        // Bootstrap with our customizations (generated with Sass using Webpack)
        new Resource { ResourceType = ResourceType.Stylesheet, Url = $"{Defaults.ThemePath}/theme.min.css" },
        // Bootstrap JS
        new Resource { ResourceType = ResourceType.Script, Url = $"{Defaults.ThemePath}/bootstrap.bundle.min.js" },
        // Theme JS for page classes, Up-button etc.
        new Resource { ResourceType = ResourceType.Script, Url = $"{Defaults.ThemePath}/ambient.js" },
    };

    // Panes of the layout
    public const string PaneNameHeader = "Header";
    public const string PaneNameContent = "Content"; // TODO: Default
    public override string Panes => string.Join(",",
        /*PaneNames.Admin,*/  // Note that we don't want the AdminPane to be in the default list, as people shouldn't add modules there
        PaneNameHeader, 
        PaneNameContent);

    [Inject] protected PageCssService PageCss { get; set; }
    [Inject] protected ThemeJsService ThemeJs { get; set; }

    // TODO: Optimize so it's real-time and doesn't need StateHasChanged()
    //public bool ShowAdminPane { get; set; } = false;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        // The admin pane is only necessary for edge cases and initial demo-content of Oqtane
        // So we should try to keep it hidden, but we must show it if something is inside it.
        //var showAdminPaneBefore = ShowAdminPane;
        //ShowAdminPane = !PageCss.PaneIsEmpty(PageState, PaneNames.Admin);
        //if (showAdminPaneBefore != ShowAdminPane) StateHasChanged();

        var bodyClasses = await PageCss.BodyClasses(PageState.Page, BodyClasses);
        await ThemeJs.SetBodyClasses(bodyClasses);
    }

    /// <summary>
    /// Special classes for divs surrounding panes pane, especially to indicate when it's empty
    /// </summary>
    public string PaneClasses(string paneName) => PageCss.PaneIsEmptyClasses(PageState, paneName);
}