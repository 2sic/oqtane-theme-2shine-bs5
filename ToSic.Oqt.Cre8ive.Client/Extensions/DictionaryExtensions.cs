namespace ToSic.Oqt.Cre8ive.Client;

public static class DictionaryExtensions
{
    public static T? FindInvariant<T>(this IDictionary<string, T>? dic, string key) where T : class
        => dic?.FirstOrDefault(pair => pair.Key.EqInvariant(key)).Value;
}