using Oqtane.UI;

namespace ToSic.Oqt.Cre8ive.Client.Services;

/// <summary>
/// Special helper to figure out what classes should be applied to the page. 
/// </summary>
public class PageCssService<T> where T : ThemeDefaults, new()
{

    public PageCssService(T settings) => Settings = settings.ThemeCss;
    public ThemeCssSettings Settings { get; }

    //protected abstract ThemeCss Settings { get; }

    public string BodyClasses(PageState pageState, string layoutVariation)
    {
        var page = pageState.Page;
        //1.1 Set the page-is-home class
        var isHomeClass = page.Path == "" ? Settings.PageIsHome : "";

        //1.2 Set the page-### class
        var pageIdClass = Settings.PagePrefix + page.PageId;

        //1.3 Set the page-parent-### class
        var pageParentClass = page.ParentId == null ? null : $"{Settings.PageParentPrefix}{page.ParentId}";

        //1.4 Set the page-root-### class
        var pageParentId = page.ParentId;

        var pageRootClass = pageParentId == null 
            ? $"{Settings.PageRootPrefix}{page.PageId}" 
            : $"{Settings.PageRootPrefix}{pageState.Breadcrumb()?.FirstOrDefault()?.PageId}";


        //1.5 Set the page-root-neutral-### class

        //2 Set site-### class
        var siteIdClass = $"{Settings.SitePrefix}{page.SiteId}";

        //3 Set the nav-level-### class
        var navLevel = page.Level + 1;
        var navLevelClass = $"{Settings.NavLevelPrefix}{navLevel}";

        //4.1 Set lang- class

        //4.2 Set the lang-root- class

        //4.3 Set the lang-neutral- class

        //5.1 Set the to-shine-variation- class
        var layoutVariationClass = $"{Settings.LayoutVariationPrefix}{layoutVariation}";

        // TODO: MOVE OUT TO ThemeCss

        //5.2 Set the to-shine-mainnav-variation- class
        const string navigationVariationClass = "to-shine-mainnav-variation-right";

        string[] classes =
        {
            pageIdClass,
            pageParentClass,
            pageRootClass,
            isHomeClass,
            siteIdClass,
            navLevelClass,
            layoutVariationClass,
            navigationVariationClass,
        };

        var bodyClasses = string.Join(" ", classes).Replace("  ", " ");
        return bodyClasses;
    }

    public bool PaneIsEmpty(PageState pageState, string paneName)
    {
        var paneHasModules = pageState.Modules.Any(
            module => !module.IsDeleted
                      && module.PageId == pageState.Page.PageId
                      && module.Pane == paneName);

        return !paneHasModules;
    }

    public string PaneIsEmptyClasses(PageState pageState, string paneName)
        => PaneIsEmpty(pageState, paneName) ? Settings.PaneIsEmpty : "";
}