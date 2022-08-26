using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ToSic.Oqt.Themes.ToShineBs5.Client.Models;
using ToSic.Oqt.Themes.ToShineBs5.Client.Services;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Menu;

public abstract class MenuBase : Oqtane.Themes.Controls.MenuBase, IMenuConfig
{
    [Inject] protected MenuTreeService Navigator { get; set; }

    [Parameter] public string ConfigName { get; set; }
    [Parameter] public List<int> PageList { get; set; }
    [Parameter] public int? LevelSkip { get; set; }
    [Parameter] public int? LevelDepth { get; set; }
    [Parameter] public bool Debug { get; set; } = false;
    [Parameter] public bool? Display { get; set; } = true;
    [Parameter] public int? StartLevel { get; set; }
    [Parameter] public string Start { get; set; }


    protected MenuBranch MenuTree { get; private set; }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        MenuTree = Navigator.GetTree(new MenuConfig(this), PageState, MenuPages.ToList());
    }
}