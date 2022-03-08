using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Components;

using Oqtane.Models;
using Oqtane.UI;
using ToSic.Oqt.Themes.ToShineBs5.Client.Classes;

namespace Oqtane.Themes.Controls
{
    public abstract class MenuItem : MenuBase
    {
        [Parameter()]
        public PageNavigator PageNavigator { get; set; }
    }
}
