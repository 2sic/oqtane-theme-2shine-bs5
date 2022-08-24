﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Oqtane.Models;
using Oqtane.Services;
using Oqtane.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Linq;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Layouts;

public partial class Default : Oqtane.Themes.ThemeBase
{
    public override string Name => "Default";

    public override List<Resource> Resources => new()
    {
        // Bootstrap with our customizations (generated with Sass using Webpack)
        new Resource { ResourceType = ResourceType.Stylesheet, Url = ToShineThemePath() + "theme.min.css" },
        // Bootstrap JS
        new Resource { ResourceType = ResourceType.Script, Url = ToShineThemePath() + "bootstrap.bundle.min.js" },
        // Theme JS for page classes, Up-button etc.
        new Resource { ResourceType = ResourceType.Script, Url = ToShineThemePath() + "ambient.js" },
    };

    public override string Panes => PaneNames.Admin + ",Header,Content";

    //Set 2shine variables to define some settings for this layout
    //------------------------------------------------------------

    //ClassName variable is used to set the body class which sets the css for this specific layout
    protected virtual string ClassName => "default";

    protected virtual bool ShowSidebarNavigation => false;

    protected virtual bool ShowBreadcrumb => true;

    [Inject]
    protected HttpClient Http { get; set; }

    [Inject]
    protected IPageService PageService { get; set; }

    [Inject]
    protected ISiteService SiteService { get; set; }

    [Inject]
    protected ITenantService TenantService { get; set; }

    [Inject]
    protected ILanguageService LanguageService { get; set; }


    public static string ToShineThemePath()
    {
        return "Themes/ToSic.Oqt.Themes.ToShineBs5/";
    }

    private IJSObjectReference BodyClassJS;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        var bodyClasses = await DetermineBodyClasses();

        BodyClassJS = await JSRuntime.InvokeAsync<IJSObjectReference>("import", Path.Combine("./", ToShineThemePath(), "interop/page-control.js"));

        await BodyClassJS.InvokeAsync<string>("clearBodyClasses");
        await BodyClassJS.InvokeAsync<string>("setBodyClass", bodyClasses);
    }

    private async Task<string> DetermineBodyClasses()
    {
        var page = PageState.Page;

        //1.1 Set the page-is-home class
        var isHomeClass = page.Path == "" ? "page-is-home" : "";

        //1.2 Set the page-### class
        var pageIdClass = "page-" + page.PageId;

        //1.3 Set the page-parent-### class
        var pageParentClass = page.ParentId == null ? null : "page-parent-" + page.ParentId;

        //1.4 Set the page-root-### class
        var pageParentId = page.ParentId;
        string pageRootClass = null;
        if (pageParentId == null)
            pageRootClass = "page-root-" + page.PageId;
        else
            while (pageParentId != null)
            {
                var parentPage = await PageService.GetPageAsync((int)pageParentId);
                pageParentId = parentPage.ParentId;
                if (parentPage.ParentId == null)
                    pageRootClass = "page-root-" + parentPage.PageId;
            }

        //1.5 Set the page-root-neutral-### class

        //2 Set site-### class
        var siteIdClass = "site-" + page.SiteId;

        //3 Set the nav-level-### class
        var navLevel = page.Level + 1;
        var navLevelClass = "nav-level-" + navLevel;

        //4.1 Set lang- class

        //4.2 Set the lang-root- class

        //4.3 Set the lang-neutral- class

        //5.1 Set the to-shine-variation- class
        var layoutVariationClass = "to-shine-variation-" + ClassName;

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

        var bodyClasses = string.Join(" ", classes);

        bodyClasses = bodyClasses.Replace("  ", " ");
        return bodyClasses;
    }

    private string HeaderPaneIsEmptyClass()
    {
        var headerPaneIsEmpty = true;
        var modules = PageState.Modules.Where(x => x.PageId == PageState.Page.PageId);
        foreach(var module in modules)
            if (module.Pane == "Header")
                headerPaneIsEmpty = false;

        return headerPaneIsEmpty ? "to-shine-header-pane-empty" : string.Empty;
    }
}