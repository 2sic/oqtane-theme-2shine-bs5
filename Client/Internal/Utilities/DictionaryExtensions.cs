using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Internal.Utilities
{
    internal static class DictionaryExtensions
    {
        public static T FindInvariant<T>(this IDictionary<string, T> dic, string key) where T : class
            => dic?.FirstOrDefault(pair =>
                string.Equals(pair.Key, key, StringComparison.InvariantCultureIgnoreCase)).Value;
    }
}
