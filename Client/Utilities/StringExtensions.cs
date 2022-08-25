using static System.StringComparison;

namespace ToSic.Oqt.Themes.ToShineBs5.Client.Utilities
{
    internal static class StringExtensions
    {
        public static bool EqInvariant(this string a, string b)
            => a == null && b == null
               || string.Equals(a, b, InvariantCultureIgnoreCase);

        public static bool HasValue(this string value)
            => !string.IsNullOrEmpty(value);
    }
}
