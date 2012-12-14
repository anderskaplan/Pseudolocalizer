namespace PseudoLocalizer.Core
{
    using System.Linq;

    /// <summary>
    /// A transform which reverses (mirrors) all strings.
    /// </summary>
    public static class Mirror
    {
        public static string Transform(string value)
        {
            return new string(value.Reverse().ToArray());
        }
    }
}
