namespace ToSic.Oqt.Cre8Magic.Client.Styling;

/// <summary>
/// Constants and helpers related to creating Css and Css Classes.
///
/// If you change these, you must also update the SCSS files. 
/// </summary>
public class MagicPageDesign
{
    private const string SitePrefixDefault = "site-";
    private const string PagePrefixDefault = "page-";
    internal const string MainPrefix = "to-shine-";
    private const string PanePrefixDefault = "pane-";
    internal const string ModulePrefixDefault = "module-";
    private const string MenuLevelPrefixDefault = "nav-level-";
    internal const string BodyDivId = "cre8magic-root";

    public const string SettingFromDefaults = $"{MainPrefix}warning-this-is-from-defaults-you-should-set-your-own-value";

    public string[] MagicClasses { get; set; } =
    {
        //1.2 Set the page-### class
        $"{PagePrefixDefault}{MagicPlaceholders.PageId}",
        //1.4 Set the page-root-### class
        $"{PagePrefixDefault}root-{MagicPlaceholders.PageRootId}",
        //1.3 Set the page-parent-### class
        $"{PagePrefixDefault}parent-{MagicPlaceholders.PageParentId}",
        //2 Set site-### class
        $"{SitePrefixDefault}{MagicPlaceholders.SiteId}",
        //3 Set the nav-level-### class
        $"{MenuLevelPrefixDefault}{MagicPlaceholders.MenuLevel}",
        //5.1 Set the to-shine-variation- class
        $"{MainPrefix}variation-{MagicPlaceholders.LayoutVariation}",

        // TODO: FIND OUT IF we need this
        // and where to put it
        //5.2 Set the to-shine-mainnav-variation- class
        $"{MainPrefix}mainnav-variation-right",
    };

    public string PageIsHome { get; set; } = $"{PagePrefixDefault}is-home";


    public string PaneIsEmpty { get; set; } = $"{PanePrefixDefault}is-empty";

    public string MagicContextTagId { get; set; } = BodyDivId;

    public static MagicPageDesign Defaults = new();
}