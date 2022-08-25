//using System.Collections.Generic;
//using System.Linq;
//using Oqtane.Models;
//using Oqtane.UI;

//namespace ToSic.Oqt.Themes.ToShineBs5.Client.Nav
//{
//    public class BreadcrumbNav
//    {
//        public Page Home(PageState pageState) => pageState.Pages.Find(p => p.Path == "");

//        public IEnumerable<Page> Breadcrumb(PageState pageState) 
//            => GetBreadCrumbPages(pageState).Reverse().ToList();

//        private IEnumerable<Page> GetBreadCrumbPages(PageState pageState)
//        {
//            var page = pageState.Page;
//            do
//            {
//                yield return page;
//                page = pageState.Pages.FirstOrDefault(p => p.PageId == page?.ParentId);

//            } while (page != null);
//        }
//    }
//}
