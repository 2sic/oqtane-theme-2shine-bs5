using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Oqtane.Services;
using Oqtane.UI;
using ToSic.Oqt.Themes.ToShineBs5.Client.Utilities;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Controls;

/// <summary>
/// Helper to remove the logic/code from the razor file.
/// It's just meant to support the AdminButtons,
/// without placing the logic code inside that. 
/// </summary>
public class AdminActions
{
    public IPageService PageService { get; }
    public NavigationManager NavigationManager { get; }

    public AdminActions(IPageService pageService, NavigationManager navigationManager)
    {
        PageService = pageService;
        NavigationManager = navigationManager;
    }

    // Code basically copied from ControlPanel.razor
    public async Task ToggleEditMode(PageState pageState)
    {
        if (pageState.UserIsEditor())
            pageState.EditMode = !pageState.EditMode;
        else if (pageState.Page.IsPersonalizable && pageState.User != null)
        {
            // Unclear what this is for, so just a guess
            // Probably the personalizable page is "virtual" so if he's on that page
            // He doesn't have a personalizable page yet, so it must be created.
            // I assume afterwards he would always be on that page, so it wouldn't create it any more
            await PageService.AddPageAsync(pageState.Page.PageId, pageState.User.UserId);
            pageState.EditMode = !pageState.EditMode;
        }
        // Note: I assume that if the user had just created his own page, this would result in a redirect
        NavigationManager.NavigateTo(Oqtane.Shared.Utilities.NavigateUrl(pageState.Alias.Path, pageState.Page.Path, "edit=" + (pageState.EditMode ? "1" : "0")));
    }

}