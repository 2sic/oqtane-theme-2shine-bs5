using System.Collections.Generic;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Models
{
    public class MenuCssConfig
    {
        public MenuCssTagConfig Ul { get; set; }
        public MenuCssTagConfig Li { get; set; }
        public MenuCssTagConfig A { get; set; }
    }

    public class MenuCssTagConfig
    {
        public string Classes { get; set; }
        
        public Dictionary<int, string> ByLevel { get; set; }

        public string Active { get; set; }
        public string NotActive { get; set; }

        public string HasChildren { get; set; }
        public string NoChildren { get; set; }

        public string Disabled { get; set; }
        public string Enabled { get; set; }
    }
}
