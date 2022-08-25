using System.Linq;
using Oqtane.Models;
using ToSic.Oqt.Themes.ToShineBs5.Client.Utilities;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Layouts
{
    internal class ContainerCss
    {
        public string Classes(Module module) => string.Join(" ", new[]
        {
            module.IsPublished() ? "" : "module-unpublished", // Info-Class if not published
            module.UseAdminContainer ? "to-shine-admin-container" : "" // Info-class if admin module
        }.Where(s => !string.IsNullOrEmpty(s)));
    }
}
