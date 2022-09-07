using static System.StringComparer;

namespace ToSic.Oqt.Cre8Magic.Client.Settings;

/// <summary>
/// Case insensitive dictionary managing a list of named settings
/// </summary>
/// <typeparam name="T"></typeparam>
public class NamedSettings<T>: Dictionary<string, T> where T : class
{
    public NamedSettings() : base(InvariantCultureIgnoreCase) { }

    public NamedSettings(IDictionary<string, T> dic): base(dic, InvariantCultureIgnoreCase) { }

    public NamedSettings(IEnumerable<KeyValuePair<string, T>> dic): base(dic, InvariantCultureIgnoreCase) { }

    public T? GetInvariant(string key) => TryGetValue(key, out var value) ? value : default;
}