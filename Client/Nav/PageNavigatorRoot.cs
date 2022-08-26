﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Oqtane.Models;
using ToSic.Oqt.Themes.ToShineBs5.Client.Models;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Nav
{
    public class PageNavigatorRoot: PageNavigator
    {
        public IMenuConfig Config { get; }
        public List<Page> AllPages { get; }

        /// <summary>
        /// Pages in the menu according to Oqtane pre-processing
        /// Should be limited to pages which should be in the menu, visible and permissions ok. 
        /// </summary>
        public List<Page> MenuPages;

        public List<string> DebugLog = new();

        public override PageNavigatorRoot RootNavigator => this;

        public PageNavigatorRoot([NotNull] IMenuConfig config, [NotNull] List<Page> allPages, [NotNull] List<Page> menuPages, [NotNull] Page currentPage) 
            : base(null, 0, (config.LevelDepth ?? MenuConfig.LevelDepthDefault) + 1, currentPage)
        {
            Config = config;
            AllPages = allPages;
            MenuPages = menuPages;

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
                return GetRelatedPagesByLevel(CurrentPage, relatedPageLevel);

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
            

            var childPages = new List<Page>();
            // Case 1
            // StartPage + Levels to Skip
            // B: StartPageS

            // Case 2
            // No start page + levels to skip



            var startPage = !string.IsNullOrWhiteSpace(Config.Start)
                ? Config.Start
                : MenuConfig.StartPageDefault;
            //if (Config.StartingPage != null)
            //{
            if (startPage == MenuConfig.StartPageRoot)
                childPages = MenuPages.Where(p => p.Level == (Config.LevelSkip ?? MenuConfig.LevelSkipDefault)).ToList();
            else if (int.TryParse(startPage, out var pageId))
                try
                {
                    var page = MenuPages.FirstOrDefault(p => p.PageId == pageId);
                    if (page != null)
                    {
                        if (Config.LevelSkip != null && Config.LevelSkip != 0)
                        {
                            var targetLevel = page.Level + (Config.LevelSkip ?? MenuConfig.LevelSkipDefault);
                            childPages = MenuPages.Where(p => p.Level == targetLevel).ToList();
                        }

                        childPages.Add(page);
                    }
                    else
                        childPages.Add(ErrPage(pageId, $"Error: Page {pageId} not found"));
                }
                catch (Exception ex)
                {
                    childPages.Add(ErrPage(pageId, $"Error: Page {pageId} - unexpected error {ex.Message}"));
                }
            else
                childPages.Add(ErrPage(pageId, $"Error: StartPage '{Config.Start}' Config unexpected"));

            //}

            if (Config.StartLevel != null)
                childPages = MenuPages.Where(p => p.Level == Config.StartLevel).ToList();

            if (Config.PageList != null)
                foreach (var pageId in Config.PageList)
                    try
                    {
                        childPages.Add(MenuPages.Single(p => p.PageId == pageId));
                    }
                    catch (Exception ex)
                    {
                        childPages.Add(ErrPage(pageId, $"Error: PageList '{pageId}' invalid - {ex.Message}"));
                    }

            //var childNavigators = childPages
            //    .Select(childPage => new PageNavigator(AllPages, 1, Config.LevelDepth ?? MenuConfig.LevelDepthDefault, childPage))
            //    .ToList();

            return childPages;// childNavigators;
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
                .Where(i => i!=int.MinValue)
                .ToArray();
            return result;
        }
    }
}
