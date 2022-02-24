using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using Oqtane.Models;
using Oqtane.Services;
using Oqtane.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ToSic.Oqt.Themes.ToShineBs5
{
    public partial class Default : Oqtane.Themes.ThemeBase
    {
        protected virtual string ClassName => "default";

        protected virtual bool ShowSidebarNavigation => false;

        protected virtual bool ShowBreadcrumb => true;

        public override string Name => "default";

        public override string Panes => PaneNames.Admin + ",Header,Content";

        public override List<Resource> Resources => new List<Resource>()
        {
		    // Load Theme which contains Bootstrap with our customizations (generated with Sass using Webpack)
            new Resource { ResourceType = ResourceType.Stylesheet, Url = ThemePath() + "theme.min.css" },
            // Load the default BS JS
            new Resource { ResourceType = ResourceType.Script, Url = ThemePath() + "bootstrap.bundle.min.js" },
            // Our custom code which ensures page classes, Up-button etc.
            new Resource { ResourceType = ResourceType.Script, Url = ThemePath() + "background.js" },
        };

        [Inject]
        protected IPageService PageService { get; set; }

        [Inject]
        protected ISiteService SiteService { get; set; }

        [Inject]
        protected ITenantService TenantService { get; set; }

        [Inject]
        protected ILanguageService LanguageService { get; set; }

        private IJSObjectReference BodyClassJS;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            string bodyClasses = await DetermineBodyClasses();
            BodyClassJS = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./Themes/ToSic.Oqt.Themes.ToShineBs5/page-control.js");
            await BodyClassJS.InvokeAsync<string>("clearBodyClasses");
            await BodyClassJS.InvokeAsync<string>("setBodyClass", bodyClasses);
        }

        private async Task<string> DetermineBodyClasses()
        {
            var page = this.PageState.Page;
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
            {
                pageRootClass = "page-root-" + page.PageId;
            }
            else
            {
                while (pageParentId != null)
                {
                    var parentPage = await PageService.GetPageAsync((int)pageParentId); ;
                    pageParentId = parentPage.ParentId;
                    if (parentPage.ParentId == null)
                    {
                        pageRootClass = "page-root-" + parentPage.PageId;
                    }
                }
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
            var layoutVarriationClass = "to-shine-variation-" + ClassName;

            //5.2 Set the to-shine-mainnav-variation- class

            string[] classes =
            {
                pageIdClass,
                pageParentClass,
                pageRootClass,
                isHomeClass,
                siteIdClass,
                navLevelClass,
                layoutVarriationClass,
            };

            string bodyClasses = string.Join(" ", classes);

            bodyClasses = bodyClasses.Replace("  ", " ");
            return bodyClasses;
        }
    }
}