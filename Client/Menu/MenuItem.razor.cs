using ToSic.Oqt.Themes.ToShineBs5.Client.Services;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu;

public partial class MenuItem
{
    // WIP
    protected override MenuCss MenuCss { get; } = new(new())
    {
        LinkCustom = branch =>
        {
            var cls = branch.MenuLevel == 1 ? "nav-link" : "dropdown-item";
            if (branch.HasChildren)
                cls += " dropdown-toggle";
            return cls;
        },
        ItemCustom = branch => branch.HasChildren ? "dropdown" : null
    };
}