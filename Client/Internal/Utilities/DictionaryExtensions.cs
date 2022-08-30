using System.Linq;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Internal.Utilities
{
    internal static class DictionaryExtensions
    {
        public static T FindInvariant<T>(this IDictionary<string, T> dic, string key) where T : class
            => dic?.FirstOrDefault(pair => pair.Key.EqInvariant(key)
        /*string.Equals(pair.Key, key, StringComparison.InvariantCultureIgnoreCase)*/).Value;
    }
}
