using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Localization;
using Microsoft.JSInterop;
using System.Globalization;
using System.Threading.Tasks;
using Oqtane.Services;
using Oqtane.UI;
using System.Linq;
using static Microsoft.AspNetCore.Localization.CookieRequestCultureProvider;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services;

/*
 * Todo:
 * - make list of languages optional in the skin
 * - if supplied, it must use the order it was given in the skin params
 * - ...and only show these; possibly show more to admin?
 */

public class LanguageService
{
    public LanguageService(NavigationManager navigation, IJSRuntime jsRuntime, ILanguageService languageService)
    {
        _navigationManager = navigation;
        _jsRuntime = jsRuntime;
        _languageService = languageService;
    }

    private readonly NavigationManager _navigationManager;
    private readonly IJSRuntime _jsRuntime;
    private readonly ILanguageService _languageService;

    public async Task<List<SettingsLanguage>> LanguagesToShow(PageState pageState, string themeLanguages)
    {
        var siteLanguages = await _languageService.GetLanguagesAsync(pageState.Site.SiteId);

        // Figure out list of languages if specified in in the parameters
        (string Code, string Label)[] customList = string.IsNullOrWhiteSpace(themeLanguages)
            ? Array.Empty<(string, string)>()
            : themeLanguages.Split(",")
                .Select(l =>
                {
                    var parts = l.Split(":");
                    return (parts[0].Trim(), parts.Length > 1 ? parts[1].Trim() : null);
                })
                .Where(s => s.Item1.HasValue())
                .ToArray();

        // Primary order of languages. If specified, use that, otherwise use site list
        var primaryOrder = customList.Any()
            ? customList.Select(l => l.Code)
            : siteLanguages.Select(l => l.Code);

        // Create list with Code, Label and Title
        var result = primaryOrder
            .Select(code =>
            {
                var customLabel = customList.FirstOrDefault(l => l.Code.EqInvariant(code));
                var label = (customLabel != default ? customLabel.Label : null)
                            ?? code[..2].ToUpperInvariant();

                var langInSite = siteLanguages.Find(al => al.Code.EqInvariant(code));
                return new SettingsLanguage() { Culture = code, Label = label, Description = langInSite?.Name };
            })
            .Where(set => set.Description.HasValue())
            .ToList();
        return result;
    }

    public async Task SetCultureAsync(string culture)
    {
        if (culture == CultureInfo.CurrentUICulture.Name) return;

        var interop = new Interop(_jsRuntime);
        var localizationCookieValue = MakeCookieValue(new RequestCulture(culture));
        await interop.SetCookie(DefaultCookieName, localizationCookieValue, 360);

        _navigationManager.NavigateTo(_navigationManager.Uri, forceLoad: true);
    }
}