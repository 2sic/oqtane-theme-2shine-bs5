using Oqtane.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using ToSic.Oqt.Themes.ToShineBs5.Client.Models;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Nav;

public class PageNavigatorService
{
    //private List<Page> MenuPages { get; set; }

    //private MenuConfig Config { get; set; }

    [return: NotNull]
    public PageNavigator Start(MenuConfig config, List<Page> allPages, List<Page> menuPages, Page currentPage)
    {
        //MenuPages = menuPages;
        //Config = config;
        //var children = InitialChildren();
        return new PageNavigatorRoot(config, allPages, menuPages, currentPage);
    }

    //private List<Page> InitialChildren()
    //{
    //    // Give empty list if we shouldn't display it
    //    if (Config.Display == false) return new();

    //    // Case 1: StartPage *, so all top-level entries
    //    var start = Config.Start?.Trim();
    //    if (start is null or MenuConfig.StartPageRoot)
    //        return MenuPages.Where(p => p.Level == 0).ToList();

    //    // Case 2: '.' - not yet supported
    //    if (start == MenuConfig.StartPageCurrent)
    //    {

    //    }
    //    if (int.TryParse(start, out var starPage))
    //    {

    //    }

    //    var childPages = new List<Page>();
    //    // Case 1
    //    // StartPage + Levels to Skip
    //    // B: StartPageS

    //    // Case 2
    //    // No start page + levels to skip



    //    var startPage = !IsNullOrWhiteSpace(Config.Start) 
    //        ? Config.Start 
    //        : MenuConfig.StartPageDefault;
    //    //if (Config.StartingPage != null)
    //    //{
    //        if (startPage == MenuConfig.StartPageRoot)
    //            childPages = MenuPages.Where(p => p.Level == (Config.LevelSkip ?? MenuConfig.LevelSkipDefault)).ToList();
    //        else if (int.TryParse(startPage, out var pageId))
    //            try
    //            {
    //                var page = MenuPages.FirstOrDefault(p => p.PageId == pageId);
    //                if (page != null)
    //                {
    //                    if (Config.LevelSkip != null && Config.LevelSkip != 0)
    //                    {
    //                        var targetLevel = page.Level + (Config.LevelSkip ?? MenuConfig.LevelSkipDefault);
    //                        childPages = MenuPages.Where(p => p.Level == targetLevel).ToList();
    //                    }

    //                    childPages.Add(page);
    //                }
    //                else
    //                    childPages.Add(ErrPage(pageId, $"Error: Page {pageId} not found"));
    //            }
    //            catch (Exception ex)
    //            {
    //                childPages.Add(ErrPage(pageId, $"Error: Page {pageId} - unexpected error {ex.Message}"));
    //            }
    //        else
    //            childPages.Add(ErrPage(pageId, $"Error: StartPage '{Config.Start}' Config unexpected"));

    //    //}

    //    if (Config.StartLevel != null) 
    //        childPages = MenuPages.Where(p => p.Level == Config.StartLevel).ToList();

    //    if (Config.PageList != null)
    //        foreach (var pageId in Config.PageList)
    //            try
    //            {
    //                childPages.Add(MenuPages.Single(p => p.PageId == pageId));
    //            }
    //            catch (Exception ex)
    //            {
    //                childPages.Add(ErrPage(pageId, $"Error: PageList '{pageId}' invalid - {ex.Message}"));
    //            }

    //    //var childNavigators = childPages
    //    //    .Select(childPage => new PageNavigator(AllPages, 1, Config.LevelDepth ?? MenuConfig.LevelDepthDefault, childPage))
    //    //    .ToList();

    //    return childPages;// childNavigators;
    //}

    //private static Page ErrPage(int id, string message)
    //    => new Page { PageId = id, Name = message };
}