using System.Collections.Generic;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Models
{
    public class MenuCssConfig
    {
        public Dictionary<string, MenuCssTagConfig> Parts { get; set; } = new();
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

        // @2tl needed?
        public string OrderIsFirst { get; set; }
    }
}
