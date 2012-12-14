namespace PseudoLocalizer.Core
{
    /// <summary>
    /// A transform which adds brackets to all strings.
    /// </summary>
    public static class Brackets
    {
        public static string Transform(string value)
        {
            return "[" + value + "]";
        }
    }
}
