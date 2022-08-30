using Oqtane.Models;
using static ToSic.Oqt.Themes.ToShineBs5.Client.ThemeCss;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services;

/// <summary>
/// Note: ATM not a real service yet, so we don't add "Service" to the name as of now.
/// </summary>
internal class ContainerCss
{
    public string Classes(Module module) => string.Join(" ", new[]
    {
        module.IsPublished() ? "" : ModuleUnpublished, // Info-Class if not published
        module.UseAdminContainer ? LayoutAdminContainer : "" // Info-class if admin module
    }.Where(s => !string.IsNullOrEmpty(s)));
}