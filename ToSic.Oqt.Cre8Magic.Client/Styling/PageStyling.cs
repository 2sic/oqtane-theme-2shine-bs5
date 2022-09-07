namespace ToSic.Oqt.Cre8Magic.Client.Styling;

/// <summary>
/// Constants and helpers related to creating Css and Css Classes.
///
/// If you change these, you must also update the SCSS files. 
/// </summary>
public class PageStyling
{
    private const string SitePrefixDefault = "site-";
    private const string PagePrefixDefault = "page-";
    internal const string LayoutPrefixDefault = "to-shine-";
    private const string PanePrefixDefault = "pane-";
    internal const string ModulePrefixDefault = "module-";
    private const string MenuLevelPrefixDefault = "nav-level-";
    internal const string BodyDivId = "toshine-body";

    public const string SettingFromDefaults = "to-shine-warning-this-is-from-defaults-you-should-set-your-own-value";

    public string[] BodyClasses { get; set; } =
    {
        //1.2 Set the page-### class
        $"{PagePrefixDefault}{Placeholders.PageId}",
        //1.4 Set the page-root-### class
        $"{PagePrefixDefault}root-{Placeholders.PageRootId}",
        //1.3 Set the page-parent-### class
        $"{PagePrefixDefault}parent-{Placeholders.PageParentId}",
        //2 Set site-### class
        $"{SitePrefixDefault}{Placeholders.SiteId}",
        //3 Set the nav-level-### class
        $"{MenuLevelPrefixDefault}{Placeholders.MenuLevel}",
        //5.1 Set the to-shine-variation- class
        $"{LayoutPrefixDefault}variation-{Placeholders.LayoutVariation}",

        // TODO: FIND OUT IF we need this
        // and where to put it
        //5.2 Set the to-shine-mainnav-variation- class
        "to-shine-mainnav-variation-right",
    };

    public string PageIsHome { get; set; } = $"{PagePrefixDefault}is-home";


    public string PaneIsEmpty { get; set; } = $"{PanePrefixDefault}is-empty";

    public string MagicContextId { get; set; } = BodyDivId;
}