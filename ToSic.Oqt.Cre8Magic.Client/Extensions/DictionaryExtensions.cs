using static System.StringComparer;

namespace ToSic.Oqt.Cre8Magic.Client;

public static class DictionaryExtensions
{
    internal static T? FindInvariant<T>(this IDictionary<string, T>? dic, string key) where T : class
        => dic?.FirstOrDefault(pair => pair.Key.EqInvariant(key)).Value;

    internal static Dictionary<string, T> ToInvariant<T>(this IDictionary<string, T> dic) => new(dic, InvariantCultureIgnoreCase);
}