using Microsoft.AspNetCore.Components;

namespace ToSic.Oqt.Cre8Magic.Client.Controls.Language;

public abstract class LanguageMenuBase: ControlWithSettings
{
    [Inject] private LanguageService LanguageService { get; set; }

    public List<Settings.Language> Languages { get; private set; }

    public bool? Show { get; private set; } = null;

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        LanguageService.InitSettings(Settings);

        // Load defined language list. It change unless the page is reloaded, so we can cache it on this control
        Languages ??= await LanguageService.LanguagesToShow(PageState.Site.SiteId);
        Show ??= await LanguageService.ShowMenu(PageState.Site.SiteId);
    }

    public async Task SetLanguage(string culture) => await LanguageService.SetCultureAsync(culture);



    public string? Classes(string tag, Settings.Language? lang = null) => Settings.LanguageDesign.Classes(tag, lang).EmptyAsNull();
}