namespace ToSic.Oqt.Themes.ToShineBs5.Client
{
    /// <summary>
    /// Constants and helpers related to creating Css and Css Classes
    /// </summary>
    internal class ThemeCss
    {
        public const string AssetsPath = ThemeJs.AssetsPath;

        /// <summary>
        /// Prefix for all css classes which contain information about the page.
        /// </summary>
        public const string PagePrefix = "page-";

        public const string PageIsHome = $"{PagePrefix}is-home";

        public const string PageRootPrefix = $"{PagePrefix}root-";

        public const string PageParentPrefix = $"{PagePrefix}parent-";

        /// <summary>
        /// Prefix for all CSS classes with information about the site
        /// </summary>
        public const string SitePrefix = "site-";

        public const string NavLevelPrefix = "nav-level-";

        public const string LayoutPrefix = "to-shine-";
        public const string LayoutVariationPrefix = $"{LayoutPrefix}variation-";
    }
}
