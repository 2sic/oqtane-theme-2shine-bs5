using Oqtane.UI;

namespace ToSic.Oqt.Cre8ive.Client.Services;

/// <summary>
/// Special helper to figure out what classes should be applied to the page. 
/// </summary>
public class PageCssService: ServiceWithCurrentSettings
{
    public string BodyClasses(PageState pageState, string layoutVariation)
    {
        var Css = Settings.Css;

        if (Css == null) throw new ArgumentException("Can't continue without CSS specs", nameof(Css));

        var page = pageState.Page;
        //1.1 Set the page-is-home class
        var isHomeClass = page.Path == "" ? Css.PageIsHome : "";

        //1.2 Set the page-### class
        var pageIdClass = Css.PagePrefix + page.PageId;

        //1.3 Set the page-parent-### class
        var pageParentClass = page.ParentId == null ? null : $"{Css.PageParentPrefix}{page.ParentId}";

        //1.4 Set the page-root-### class
        var pageParentId = page.ParentId;

        var pageRootClass = pageParentId == null 
            ? $"{Css.PageRootPrefix}{page.PageId}" 
            : $"{Css.PageRootPrefix}{pageState.Breadcrumb()?.FirstOrDefault()?.PageId}";


        //1.5 Set the page-root-neutral-### class

        //2 Set site-### class
        var siteIdClass = $"{Css.SitePrefix}{page.SiteId}";

        //3 Set the nav-level-### class
        var navLevel = page.Level + 1;
        var navLevelClass = $"{Css.NavLevelPrefix}{navLevel}";

        //4.1 Set lang- class

        //4.2 Set the lang-root- class

        //4.3 Set the lang-neutral- class

        //5.1 Set the to-shine-variation- class
        var layoutVariationClass = $"{Css.LayoutVariationPrefix}{layoutVariation}";

        // TODO: MOVE OUT TO ThemeCss

        //5.2 Set the to-shine-mainnav-variation- class
        const string navigationVariationClass = "to-shine-mainnav-variation-right";

        string?[] classes =
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
        => PaneIsEmpty(pageState, paneName) ? Settings.Css.PaneIsEmpty : "";
}