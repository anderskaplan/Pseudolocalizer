namespace PseudoLocalizer.Core
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Accenter
    {
        // character mappings gratefully borrowed from the Google pseudolocalization-tool.
        private static readonly Dictionary<char, char> Replacements = new Dictionary<char, char>()
        {
            { ' ', '\u2003' },
            { '!', '\u00a1' },
            { '"', '\u2033' },
            { '#', '\u266f' },
            { '$', '\u20ac' },
            { '%', '\u2030' },
            { '&', '\u214b' },
            { '\'', '\u00b4' },
            { '(', '{' },
            { ')', '}' },
            { '*', '\u204e' },
            { '+', '\u207a' },
            { ',', '\u060c' },
            { '-', '\u2010' },
            { '.', '\u00b7' },
            { '/', '\u2044' },
            { '0', '\u24ea' },
            { '1', '\u2460' },
            { '2', '\u2461' },
            { '3', '\u2462' },
            { '4', '\u2463' },
            { '5', '\u2464' },
            { '6', '\u2465' },
            { '7', '\u2466' },
            { '8', '\u2467' },
            { '9', '\u2468' },
            { ':', '\u2236' },
            { ';', '\u204f' },
            { '<', '\u2264' },
            { '=', '\u2242' },
            { '>', '\u2265' },
            { '?', '\u00bf' },
            { '@', '\u055e' },
            { 'A', '\u00c5' },
            { 'B', '\u0181' },
            { 'C', '\u00c7' },
            { 'D', '\u00d0' },
            { 'E', '\u00c9' },
            { 'F', '\u0191' },
            { 'G', '\u011c' },
            { 'H', '\u0124' },
            { 'I', '\u00ce' },
            { 'J', '\u0134' },
            { 'K', '\u0136' },
            { 'L', '\u013b' },
            { 'M', '\u1e40' },
            { 'N', '\u00d1' },
            { 'O', '\u00d6' },
            { 'P', '\u00de' },
            { 'Q', '\u01ea' },
            { 'R', '\u0154' },
            { 'S', '\u0160' },
            { 'T', '\u0162' },
            { 'U', '\u00db' },
            { 'V', '\u1e7c' },
            { 'W', '\u0174' },
            { 'X', '\u1e8a' },
            { 'Y', '\u00dd' },
            { 'Z', '\u017d' },
            { '[', '\u2045' },
            { '\\', '\u2216' },
            { ']', '\u2046' },
            { '^', '\u02c4' },
            { '_', '\u203f' },
            { '`', '\u2035' },
            { 'a', '\u00e5' },
            { 'b', '\u0180' },
            { 'c', '\u00e7' },
            { 'd', '\u00f0' },
            { 'e', '\u00e9' },
            { 'f', '\u0192' },
            { 'g', '\u011d' },
            { 'h', '\u0125' },
            { 'i', '\u00ee' },
            { 'j', '\u0135' },
            { 'k', '\u0137' },
            { 'l', '\u013c' },
            { 'm', '\u0271' },
            { 'n', '\u00f1' },
            { 'o', '\u00f6' },
            { 'p', '\u00fe' },
            { 'q', '\u01eb' },
            { 'r', '\u0155' },
            { 's', '\u0161' },
            { 't', '\u0163' },
            { 'u', '\u00fb' },
            { 'v', '\u1e7d' },
            { 'w', '\u0175' },
            { 'x', '\u1e8b' },
            { 'y', '\u00fd' },
            { 'z', '\u017e' },
            { '{', '(' },
            { '|', '\u00a6' },
            { '}', ')' },
            { '~', '\u02de' },
        };

        public static string Transform(string value)
        {
            return new string(
                value.ToCharArray()
                    .Select(x => Transform(x))
                    .ToArray());
        }

        private static char Transform(char value)
        {
            char x;
            if (Replacements.TryGetValue(value, out x))
            {
                return x;
            }
            else
            {
                return value;
            }
        }
    }
}
