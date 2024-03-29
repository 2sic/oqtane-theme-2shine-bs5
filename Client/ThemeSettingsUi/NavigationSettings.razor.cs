using Microsoft.AspNetCore.Components;

namespace ToSic.Themes.ToShineBs5.Client.ThemeSettingsUi;
public partial class NavigationSettings
{
    [Inject]
    public ThemeSettingsServiceWIPToDo SettingsServiceWipToDo { get; set; }

    [Parameter]
    public string ConfigName { get; set; }

    public ThemeSettingsContainer ThemeSettings = new();

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        var settings = SettingsServiceWipToDo.DeserializeData(ConfigName);
        if (settings != null) ThemeSettings = settings;
    }

    void OnSettingsChanged(object args)
    {
        bool.TryParse(args.ToString(), out var result);
        ThemeSettings.UseUiSettings = result;

    }

    void OnDisplayChanged(object args)
    {
        bool.TryParse(args.ToString(), out var result);
        ThemeSettings.Display = result;
    }

    void OnScopeChanged(object args)
    {
        bool.TryParse(args.ToString(), out var result);
        ThemeSettings.Display = result;
    }
}