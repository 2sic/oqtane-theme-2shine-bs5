using System.Linq;
using System.Threading.Tasks;
using Oqtane.Models;
using Oqtane.Services;
using Oqtane.UI;
using static ToSic.Oqt.Themes.ToShineBs5.Client.Layouts.ThemeCss;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Layouts;

/// <summary>
/// Special helper to figure out what classes should be applied to the page. 
/// </summary>
public class PageCss
{

    public PageCss(IPageService pageService) => _pageService = pageService;
    private readonly IPageService _pageService;

    public async Task<string> BodyClasses(Page page, string layoutVariation)
    {
        //1.1 Set the page-is-home class
        var isHomeClass = page.Path == "" ? PageIsHome : "";

        //1.2 Set the page-### class
        var pageIdClass = PagePrefix + page.PageId;

        //1.3 Set the page-parent-### class
        var pageParentClass = page.ParentId == null ? null : $"{PageParentPrefix}{page.ParentId}";

        //1.4 Set the page-root-### class
        var pageParentId = page.ParentId;
        string pageRootClass = null;
        if (pageParentId == null)
            pageRootClass = $"{PageRootPrefix}{page.PageId}";
        else
            while (pageParentId != null)
            {
                // TODO: this could be a performance killer
                // Probably better to use the mechanism also used in the Breadcrumb
                var parentPage = await _pageService.GetPageAsync((int)pageParentId);
                pageParentId = parentPage.ParentId;
                if (parentPage.ParentId == null)
                    pageRootClass = $"{PageRootPrefix}{parentPage.PageId}";
            }

        //1.5 Set the page-root-neutral-### class

        //2 Set site-### class
        var siteIdClass = $"{SitePrefix}{page.SiteId}";

        //3 Set the nav-level-### class
        var navLevel = page.Level + 1;
        var navLevelClass = $"{NavLevelPrefix}{navLevel}";

        //4.1 Set lang- class

        //4.2 Set the lang-root- class

        //4.3 Set the lang-neutral- class

        //5.1 Set the to-shine-variation- class
        var layoutVariationClass = $"{LayoutVariationPrefix}{layoutVariation}";

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

    public string PaneIsEmpty(PageState pageState, string paneName)
    {
        var paneIsEmpty = pageState.Modules
            .Where(x => x.PageId == pageState.Page.PageId)
            .All(m => m.Pane != paneName);

        return paneIsEmpty ? ThemeCss.PaneIsEmpty : "";
    }
}