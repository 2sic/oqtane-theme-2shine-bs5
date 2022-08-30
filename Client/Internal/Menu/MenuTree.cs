using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Oqtane.Models;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Internal.Menu
{
    public class MenuTree : MenuBranch
    {
        internal IMenuConfig Config { get; }
        private List<Page> AllPages { get; }

        /// <summary>
        /// Pages in the menu according to Oqtane pre-processing
        /// Should be limited to pages which should be in the menu, visible and permissions ok. 
        /// </summary>
        internal List<Page> MenuPages;

        protected override MenuTree Tree => this;

        internal MenuCss Design => _menuCss ??= new MenuCss((Config as MenuConfig)?.MenuCss);
        private MenuCss _menuCss;

        public override string Debug { get; }

        public MenuTree([NotNull] IMenuConfig config, [NotNull] List<Page> allPages, [NotNull] List<Page> menuPages, [NotNull] Page page, string debug)
            : base(null, 0, page)
        {
            Config = config;
            AllPages = allPages;
            MenuPages = menuPages;
            Debug = debug;

            // Bug in Oqtane 3.2 and before: Level isn't hydrated
            if (allPages.All(p => p.Level == 0))
                MenuPatchCode.GetPagesHierarchy(allPages);
        }

        [return: NotNull]
        protected override List<Page> GetChildPages()
        {
            // Give empty list if we shouldn't display it
            if (Config.Display == false) return new();

            // Case 1: StartPage *, so all top-level entries
            var start = Config.Start?.Trim();
            if (start is null or MenuConfig.StartPageRoot)
                return MenuPages.Where(p => p.Level == 0).ToList();

            // Case 2: '.' - not yet tested
            var relatedPageLevel = Config.StartLevel ?? MenuConfig.StartLevelDefault;
            if (start == MenuConfig.StartPageCurrent)
                return GetRelatedPagesByLevel(Page, relatedPageLevel);

            // Case 3: one or more IDs to start from
            var startIds = StringToIntArray(start);
            var startPages = FindPages(startIds);
            switch (relatedPageLevel)
            {
                case 0:
                    return startPages;
                case 1:
                    return startPages.SelectMany(p => GetRelatedPagesByLevel(p, 1)).ToList();
                default:
                    return new List<Page> { ErrPage(0, $"Error: can't get pages on level {relatedPageLevel} for '{start}'") };
            }

        }

        private List<Page> GetRelatedPagesByLevel(Page referencePage, int level)
        {
            switch (level)
            {
                case -1:
                    return ChildrenOf(referencePage.ParentId ?? 0);
                case 0:
                    return new List<Page> { referencePage };
                case 1:
                    return ChildrenOf(referencePage.PageId);
                case > 1:
                    return new List<Page> { ErrPage(0, "Error: Create menu from current page but level > 1") };
                default:
                    return new List<Page>
                        { ErrPage(0, "Error: Create menu from current page but level < -1, not yet implemented") };
            }
        }

        private int[] StringToIntArray(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return Array.Empty<int>();
            var result = value.Split(',')
                .Select(v => int.TryParse(v.Trim(), out var val) ? val : int.MinValue)
                .Where(i => i != int.MinValue)
                .ToArray();
            return result;
        }
    }
}
