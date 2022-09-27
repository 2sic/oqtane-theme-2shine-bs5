using Oqtane.Models;
using Oqtane.Shared;
using static Oqtane.Shared.ResourceType;

namespace ToSic.Themes.ToShineBs5.Client;

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
public abstract class MyThemeBase : MagicTheme
{
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
        new() { ResourceType = Stylesheet, Url = $"{ThemeInfo.ThemePath}/theme.min.css" },       // Bootstrap generated with Sass/Webpack
        new() { ResourceType = Script, Url = $"{ThemeInfo.ThemePath}/bootstrap.bundle.min.js" }, // Bootstrap JS
        new() { ResourceType = Script, Url = $"{ThemeInfo.ThemePath}/ambient.js", },             // Ambient JS for page Up-button etc.
    };

    /// <summary>
    /// The ThemePackageSettings must be set in this class, so the Settings initializer can pick it up.
    /// </summary>
    public override MagicPackageSettings ThemePackageSettings => ThemeInfo.ThemePackageDefaults;

    public override string Panes => string.Join(",", PaneNames.Default, PaneNameHeader);
}