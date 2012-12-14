namespace PseudoLocalizer.Core
{
    /// <summary>
    /// A transform which replaces all characters with underscores.
    /// </summary>
    public static class Underscores
    {
        public static string Transform(string value)
        {
            return new string('_', value.Length);
        }
    }
}
