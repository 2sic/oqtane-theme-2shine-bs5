﻿using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Localization;
using Microsoft.JSInterop;
using Oqtane.Services;
using Oqtane.UI;
using static Microsoft.AspNetCore.Localization.CookieRequestCultureProvider;
#pragma warning disable CS8602

namespace ToSic.Oqt.Cre8ive.Client.Services;

/*
 * Todo:
 * - make list of languages optional in the skin
 * - if supplied, it must use the order it was given in the skin params
 * - ...and only show these; possibly show more to admin?
 */

public class LanguageService: ServiceWithCurrentSettings
{
    public LanguageService(NavigationManager navigation, IJSRuntime jsRuntime, ILanguageService oqtLanguages)
    {
        _navigationManager = navigation;
        _jsRuntime = jsRuntime;
        _oqtLanguages = oqtLanguages;
    }

    private readonly NavigationManager _navigationManager;
    private readonly IJSRuntime _jsRuntime;
    private readonly ILanguageService _oqtLanguages;

    //public void InitSettings(CurrentSettings settings) => Settings ??= settings;

    //public CurrentSettings? Settings { get; private set; }


    public async Task<bool> ShowMenu(int siteId)
    {
        var languages = await LanguagesToShow(siteId);
        return Settings.Layout.LanguageMenuShow && Settings.Layout.LanguageMenuShowMin <= languages.Count;
    }

    public async Task<List<Language>> LanguagesToShow(int siteId)
    {
        if (_languages.TryGetValue(siteId, out var cached)) return cached;

        var siteLanguages = await _oqtLanguages.GetLanguagesAsync(siteId);

        var langSettings = Settings.Languages;// _setSrvOld.FindLanguageSettings();

        var customList = langSettings.List.Values;

        var siteLanguageCodes = siteLanguages.Select(l => l.Code).ToList();

        // Primary order of languages. If specified, use that, otherwise use site list
        var primaryOrder = (customList.Any()
                ? customList.Select(l => l.Culture)
                : siteLanguageCodes)
            .ToList();

        if (!langSettings.HideOthers && primaryOrder.Count < siteLanguages.Count)
        {
            var missingLanguages = siteLanguageCodes
                .Where(slc => !primaryOrder.Any(slc.EqInvariant)).ToList();
            primaryOrder = primaryOrder.Concat(missingLanguages).ToList();
        }

            // Create list with Code, Label and Title
        var result = primaryOrder
            .Select(code =>
            {
                var customLabel = customList.FirstOrDefault(l => l.Culture.EqInvariant(code));
                var label = customLabel?.Label
                            ?? code[..2].ToUpperInvariant();

                var langInSite = siteLanguages.Find(al => al.Code.EqInvariant(code));
                return new Language { Culture = code, Label = label, Description = langInSite?.Name };
            })
            .Where(set => set.Description.HasValue())
            .ToList();
        _languages[siteId] = result;
        return result;
    }

    private readonly Dictionary<int, List<Language>> _languages = new();

    public async Task SetCultureAsync(string culture)
    {
        if (culture == CultureInfo.CurrentUICulture.Name) return;

        var interop = new Interop(_jsRuntime);
        var localizationCookieValue = MakeCookieValue(new RequestCulture(culture));
        await interop.SetCookie(DefaultCookieName, localizationCookieValue, 360);

        _navigationManager.NavigateTo(_navigationManager.Uri, forceLoad: true);
    }
}