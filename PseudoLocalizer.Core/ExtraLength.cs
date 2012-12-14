namespace PseudoLocalizer.Core
{
    using System.Linq;

    public static class ExtraLength
    {
        public static string Transform(string value)
        {
            return string.Join(" ", 
                value.Split(' ').
                    Select(word => Lengthen(word)));
        }

        private static string Lengthen(string word)
        {
            var count = (word.Length + 2) / 3;
            return word + new string('x', count);
        }
    }
}
