using System.Collections.Generic;

// TODO
// - LevelSkip and StartLevel are confusing terms, not sure what each one does
namespace ToSic.Oqt.Themes.ToShineBs5.Client.Internal.Menu
{
    /// <summary>
    /// Interface which describes what a menu config contains.
    /// It must be an interface, because it's used for data in code, in json, as well as on Blazor components. 
    /// </summary>
    public interface IMenuConfig
    {
        /// <summary>
        /// Name to identify this configuration
        /// </summary>
        string ConfigName { get; set; }

        bool Debug { get; set; }

        /// <summary>
        /// Determines if this navigation should be shown.
        /// Mainly used for standard menus which could be disabled through configuration. 
        /// </summary>
        bool? Display { get; set; }

        /// <summary>
        /// How many level deep the navigation should show.
        /// The number is ??? relative,
        /// so if the navigation starts an level 2 then levelDepth 2 means to show levels 2 & 3 ??? verify
        /// </summary>
        int? Depth { get; set; }

        /// <summary>
        /// Levels to skip from the initial stating point.
        /// - 0 means don't skip any, so if we're starting at the root, show that level
        /// - 1 means skip the first level, so if we're starting at the root, show the children
        /// - 2 (uncommon) would mean to show the grandchildren only
        /// See inspiration context from DDRMenu https://www.dnnsoftware.com/wiki/ddrmenu-reference-guide
        /// </summary>
        int? LevelSkip { get; set; }

        /// <summary>
        /// Exact list of pages to show in this menu.
        /// TODO: MAYBE allow for negative numbers to remove them from the list?
        /// </summary>
        List<int> PageList { get; set; }

        /// <summary>
        /// The level this menu should start from.
        /// - 0 is the top level (default)
        /// - 1 is the top level containing home and other pages
        /// </summary>
        int? StartLevel { get; set; }

        /// <summary>
        /// Start page of this navigation - like home or another specific page.
        /// Can be
        /// - a specific ID
        /// - a CSV of IDs ???
        /// - `*` to indicate all pages on the specified level
        /// - `.` or `0` to indicate current page, probably not implemented yet TODO
        /// - blank / null, to use another start ???
        /// </summary>
        string Start { get; set; }

        string Design { get; set; }

        //MenuDesign MenuCss { get; set; }
    }
}
