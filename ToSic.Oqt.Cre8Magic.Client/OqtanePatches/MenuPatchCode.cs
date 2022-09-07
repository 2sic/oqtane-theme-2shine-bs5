using Oqtane.Models;
// ReSharper disable ConvertToLocalFunction
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
// ReSharper disable AccessToModifiedClosure
#pragma warning disable CS8625
#pragma warning disable CS8600
#pragma warning disable CS8602

namespace ToSic.Oqt.Cre8Magic.Client.OqtanePatches;

public class MenuPatchCode
{
    /// <summary>
    /// Patch - copied from the Oqtane PageService v3.2 where it's a private function.
    /// Should correct all the page level to be sure they are up to date.
    ///
    /// Once Oqtane ensures that the Level is correctly hydrated, this code should be removed
    /// https://github.com/oqtane/oqtane.framework/issues/2381
    /// </summary>
    /// <param name="pages"></param>
    /// <returns></returns>
    public static List<Page> GetPagesHierarchy(List<Page> pages)
    {
        List<Page> hierarchy = new List<Page>();
        Action<List<Page>, Page> getPath = null;
        getPath = (pageList, page) =>
        {
            IEnumerable<Page> children;
            int level;
            if (page == null)
            {
                level = -1;
                children = pages.Where(item => item.ParentId == null);
            }
            else
            {
                level = page.Level;
                children = pages.Where(item => item.ParentId == page.PageId);
            }
            foreach (Page child in children)
            {
                child.Level = level + 1;
                child.HasChildren = pages.Any(item => item.ParentId == child.PageId);
                hierarchy.Add(child);
                getPath(pageList, child);
            }
        };
        pages = pages.OrderBy(item => item.Order).ToList();
        getPath(pages, null);

        // add any non-hierarchical items to the end of the list
        foreach (Page page in pages)
        {
            if (hierarchy.Find(item => item.PageId == page.PageId) == null)
            {
                hierarchy.Add(page);
            }
        }
        return hierarchy;
    }
}