﻿using System.Collections.Generic;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Internal.Menu
{
    public class MenuDesign
    {
        public Dictionary<string, MenuPartCssConfig> Parts { get; set; } = new();
    }

    public class MenuPartCssConfig
    {
        /// <summary>
        /// Classes which are applied to all the tags of this type
        /// </summary>
        public string Classes { get; set; }
        
        /// <summary>
        /// List of classes to add on certain levels only.
        /// Use level -1 to specify classes to apply to all the remaining ones which are not explicitly listed.
        /// </summary>
        public Dictionary<int, string> ByLevel { get; set; }


        public string Active { get; set; }
        public string ActiveFalse { get; set; }

        public string HasChildren { get; set; }
        public string HasChildrenFalse { get; set; }

        
        public string Disabled { get; set; }
        public string DisabledFalse { get; set; }
    }
}