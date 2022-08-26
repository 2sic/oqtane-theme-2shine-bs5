using System.Collections.Generic;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Models
{
    public interface IMenuConfig
    {
        /// <summary>
        /// Name to identify this configuration
        /// </summary>
        string ConfigName { get; set; }
        bool? Display { get; set; }

        int? LevelDepth { get; set; }
        int? LevelSkip { get; set; }

        List<int> PageList { get; set; }

        int? StartLevel { get; set; }

        /// <summary>
        /// Start page of this navigation - like home or another specific page
        /// </summary>
        string StartPage { get; set; }
    }
}
