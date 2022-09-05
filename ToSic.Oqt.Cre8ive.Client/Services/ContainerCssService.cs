using Oqtane.Models;

namespace ToSic.Oqt.Cre8ive.Client.Services;

/// <summary>
/// Note: ATM not a real service yet, so we don't add "Service" to the name as of now.
/// </summary>
public class ContainerCssService: ServiceWithCurrentSettings
{
    public string Classes(Module module)
    {
        // Settings are null because something went really wrong
        // ...or the theme is loading a different theme, which doesn't pass settings down the value chain
        if (Settings == null)
            return "error-class-settings-not-set error-could-be-wrong-theme error-verify-the-theme-passes-settings";

        return string.Join(" ", new[]
        {
            module.IsPublished() ? "" : Settings.Css.ModuleUnpublished, // Info-Class if not published
            module.UseAdminContainer ? Settings.Css.LayoutAdminContainer : "" // Info-class if admin module
        }.Where(s => !string.IsNullOrEmpty(s)));
    }
}