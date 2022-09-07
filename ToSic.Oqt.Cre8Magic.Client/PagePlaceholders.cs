using Oqtane.Models;
using Oqtane.UI;
using static ToSic.Oqt.Cre8Magic.Client.MagicPlaceholders;
using static System.StringComparison;

namespace ToSic.Oqt.Cre8Magic.Client;

internal class PagePlaceholders
{
    private readonly PageState _pageState;
    private readonly string? _layoutVariation;
    private readonly string? _menuId;
    private readonly Page _page;

    public PagePlaceholders(PageState pageState, string? layoutVariation = null, string? menuId = null)
    {
        _pageState = pageState;
        _layoutVariation = layoutVariation;
        _menuId = menuId;
        _page = pageState.Page;
    }

    internal string Replace(string classes, Page? page = null)
    {
        if (string.IsNullOrWhiteSpace(classes)) return classes;
        page ??= _page;
        var result = classes
            .Replace(PageId, $"{page.PageId}", InvariantCultureIgnoreCase);

        // If there are no placeholders left, exit
        if (!result.Contains(PlaceholderMarker)) return result;

        result = result
            .Replace(PageParentId, page.ParentId != null ? $"{page.ParentId}" : None)
            .Replace(SiteId, $"{page.SiteId}", InvariantCultureIgnoreCase)
            .Replace(LayoutVariation, _layoutVariation ?? None)
            .Replace(MenuLevel, $"{page.Level + 1}")
            .Replace(MenuId, _menuId ?? None);

        // Checking the breadcrumb is a bit more expensive, so be sure we need it
        if (result.Contains(PageRootId))
            result = result
                .Replace(PageRootId, CurrentPageRootId != null ? $"{CurrentPageRootId}" : None);

        return result;
    }

    private int? CurrentPageRootId
    {
        get
        {
            if (_pageRootAlreadyTried) return _pageRootId;
            _pageRootAlreadyTried = true;
            _pageRootId = _pageState.Breadcrumb().FirstOrDefault()?.PageId;
            return _pageRootId;
        }
    }

    private int? _pageRootId;
    private bool _pageRootAlreadyTried;
}