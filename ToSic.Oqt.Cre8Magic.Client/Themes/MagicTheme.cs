using Microsoft.AspNetCore.Components;
using ToSic.Oqt.Cre8Magic.Client.DynComponents;
using ToSic.Oqt.Cre8Magic.Client.Styling;

namespace ToSic.Oqt.Cre8Magic.Client.Themes;

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
public abstract class MagicTheme : Oqtane.Themes.ThemeBase
{

    /// <summary>
    /// Name to show in the Theme-picker.
    /// Must be set by each inheriting theme. 
    /// </summary>
    public abstract override string Name { get; }

    /// <summary>
    /// The layout name which is used to lookup configurations.
    /// The inheriting file is required to specify it. 
    /// </summary>
    public abstract string Layout { get; }

    /// <summary>
    /// Sets additional body classes - usually to activate CSS variations for this theme
    /// </summary>
    protected abstract string BodyClasses { get; }

    /// <summary>
    /// WIP
    /// inspired by http://www.binaryintellect.net/articles/a92dea29-3218-4d1c-a132-9671b518d1f4.aspx
    /// </summary>
    protected List<DynComponent> DynComponents { get; } = new();

    // Panes of the layout
    public const string PaneNameDefault = "Default";
    public const string PaneNameHeader = "Header";

    /// <summary>
    /// Force the user to overwrite panes.
    /// </summary>
    public abstract override string Panes { get; }

    [Inject]
    protected MagicSettingsService MagicSettingsService
    {
        get => _magicSettingsService;
        set => _magicSettingsService = value.InitSettings(ThemePackageSettings);
    }
    private MagicSettingsService _magicSettingsService;

    private MagicPageDesigner PageDesigner => MagicSettingsService.PageDesigner;

    /// <summary>
    /// The settings of this layout, as loaded from the ThemePackageSettings + JSON
    /// </summary>
    protected MagicSettings Settings { get; set; }

    /// <summary>
    /// This contains the default settings which must be used in this theme.
    /// Any inheriting class must specify what it will be. 
    /// </summary>
    public abstract MagicPackageSettings ThemePackageSettings { get; }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
        Settings = MagicSettingsService.CurrentSettings(PageState, Layout, BodyClasses);
    }

    /// <summary>
    /// Special classes for divs surrounding panes pane, especially to indicate when it's empty
    /// </summary>
    public string PaneClasses(string paneName) => PageDesigner.PaneIsEmptyClasses(PageState, paneName);
}