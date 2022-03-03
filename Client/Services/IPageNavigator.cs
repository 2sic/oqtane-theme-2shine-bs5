using Oqtane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services
{
    public interface IPageNavigator
    {
        public Task<IEnumerable<Page>> Test();
    }
}
