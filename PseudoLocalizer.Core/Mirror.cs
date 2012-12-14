namespace PseudoLocalizer.Core
{
    using System.Linq;

    public static class Mirror
    {
        public static string Transform(string value)
        {
            return new string(value.Reverse().ToArray());
        }
    }
}
