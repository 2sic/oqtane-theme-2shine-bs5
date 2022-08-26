using Oqtane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ToSic.Oqt.Themes.ToShineBs5.Client.Models;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Nav;

public class PageNavigatorService
{
    private IEnumerable<Page> AllPages { get; set; }

    private MenuConfig Config { get; set; }

    public PageNavigator Start(IEnumerable<Page> menuPages, MenuConfig config/*, int levelDepth, bool display, int levelSkip, string startPage = null, int? startLevel = null, List<int> pageList = null*/)
    {
        AllPages = menuPages;
        Config = config;
        //Config = new MenuConfig
        //{
        //    PageList = pageList,
        //    Display = display,
        //    LevelDepth = levelDepth,
        //    LevelSkip = levelSkip,
        //    StartingPage = startPage,
        //    StartLevel = startLevel,
        //};

        var children = DetermineChildren();
        return new PageNavigator(AllPages, 0, Config.LevelDepth ?? MenuConfig.LevelDepthDefault, null, children);
    }

    private IList<PageNavigator> DetermineChildren()
    {
        // Give empty list if we shouldn't display it
        if (!(Config.Display ?? MenuConfig.DisplayDefault)) return new List<PageNavigator>();

        IList<Page> childPages = new List<Page>();

        var startPage = Config.StartPage ?? MenuConfig.StartPageDefault;
        //if (Config.StartingPage != null)
        //{
            if (startPage == MenuConfig.StartPageDefault)
                childPages = AllPages.Where(p => p.Level == Config.LevelSkip).ToList();
            else if (int.TryParse(startPage, out var pageId))
                try
                {
                    var page = AllPages.Single(p => p.PageId == pageId);
                    if (Config.LevelSkip != 0)
                    {
                        var targetLevel = page.Level + Config.LevelSkip;
                        childPages = AllPages.Where(p => p.Level == targetLevel).ToList();
                    }

                    childPages.Add(page);
                }
                catch
                {
                    throw new ArgumentException("The parameter StartingPoint was given an invalid PageId:" + pageId);
                }
            else
                throw new ArgumentException($"The parameter {Config.StartPage} was given an invalid input" +
                                            Config.StartPage);
        //}

        if (Config.StartLevel != null) 
            childPages = AllPages.Where(p => p.Level == Config.StartLevel).ToList();

        if (Config.PageList != null)
            foreach (var pageId in Config.PageList)
                try
                {
                    childPages.Add(AllPages.Single(p => p.PageId == pageId));
                }
                catch
                {
                    throw new ArgumentException("The parameter PageList was given an invalid PageId:" + pageId);
                }

        var childNavigators = childPages
            .Select(childPage => new PageNavigator(AllPages, 1, Config.LevelDepth ?? MenuConfig.LevelDepthDefault, childPage))
            .ToList();

        return childNavigators;
    }
}