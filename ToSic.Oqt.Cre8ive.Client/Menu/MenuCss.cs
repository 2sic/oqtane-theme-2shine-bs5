using System.Collections;

namespace ToSic.Oqt.Cre8ive.Client.Menu;

/// <summary>
/// Special helper to provide Css classes to menus
/// </summary>
public class MenuCss
{
    public MenuCss(IMenuConfig menuConfig)
    {
        MenuConfig = menuConfig as MenuConfig ?? throw new ArgumentException("MenuConfig must be real", nameof(MenuConfig));

        DesignSettingsList = new List<MenuDesignSettings> { MenuConfig.DesignSettings! };
    }
    private MenuConfig MenuConfig { get; }
    internal List<MenuDesignSettings> DesignSettingsList { get; }

    public string Classes(string tag, MenuBranch branch)
    {
        var configsForTag = DesignSettingsList
            .Select(c => c.Styling.FindInvariant(tag))
            .Where(c => c is not null)
            .ToList();

        return configsForTag.Any()
            ? ListToClasses(TagClasses(branch, configsForTag as List<MenuStyling>), branch.Page.PageId)
            : "";
    }

    private List<string?> TagClasses(MenuBranch branch, List<MenuStyling> configs)
    {
        var classes = new List<string?>();
        classes.AddRange(configs.Select(c => c.Classes));

        classes.AddRange(configs.Select(c
            => branch.IsActive ? c.Active : c.ActiveFalse));

        classes.AddRange(configs.Select(c
            => branch.HasChildren ? c.HasChildren : c.HasChildrenFalse));
        classes.AddRange(configs.Select(c
            => branch.Page.IsClickable ? c.DisabledFalse : c.Disabled));

        classes.AddRange(configs.Select(c
            => branch.InBreadcrumb ? c.InBreadcrumb : c.InBreadcrumbFalse));

        // See if there are any css for this level or for not-specified levels
        var levelCss = configs
            .Select(c => c.ByLevel == null
                ? null
                : c.ByLevel.TryGetValue(branch.MenuLevel, out var levelClasses)
                    ? levelClasses
                    : c.ByLevel.TryGetValue(Placeholders.PlaceHolderLevelOther, out var levelClassesDefault)
                        ? levelClassesDefault
                        : null);
        classes.AddRange(levelCss);

        return classes;
    }



    private string ListToClasses(IEnumerable<string?> original, int pageId)
        => string
            .Join(" ", original.Where(s => !s.IsNullOrEmpty()))
            .Replace("  ", " ")
            .Replace(Placeholders.PageId, pageId.ToString())
            .Replace(Placeholders.MenuId, MenuConfig.MenuId);


}