namespace PseudoLocalizer.Core
{
    public static class Underscores
    {
        public static string Transform(string value)
        {
            return new string('_', value.Length);
        }
    }
}
