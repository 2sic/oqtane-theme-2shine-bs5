using Oqtane.Models;

namespace ToSic.Oqt.Cre8ive.Client.Services;

/// <summary>
/// Note: ATM not a real service yet, so we don't add "Service" to the name as of now.
/// </summary>
public class ContainerCssService<T> where T: ThemeDefaults, new()
{
    public ContainerCssService(T settings) => Settings = settings;

    protected T Settings { get; }

    public string Classes(Module module) => string.Join(" ", new[]
    {
        module.IsPublished() ? "" : Settings.ThemeCss.ModuleUnpublished, // Info-Class if not published
        module.UseAdminContainer ? Settings.ThemeCss.LayoutAdminContainer : "" // Info-class if admin module
    }.Where(s => !string.IsNullOrEmpty(s)));
}