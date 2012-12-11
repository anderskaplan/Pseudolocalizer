namespace PseudoLocalizer
{
    using System.IO;
    using PseudoLocalizer.Core;

    public class Program
    {
        public static void Main(string[] args)
        {
            var inputFileName = @"c:\temp\LanguageResources.resx";
            ProcessResxFile(inputFileName);
        }

        private static void ProcessResxFile(string inputFileName)
        {
            var outputFileName = Path.Combine(Path.GetDirectoryName(inputFileName), Path.GetFileNameWithoutExtension(inputFileName) + ".qps-ploc" + Path.GetExtension(inputFileName));

            using (var inputStream = new FileStream(inputFileName, FileMode.Open, FileAccess.Read))
            using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
            {
                var processor = new ResxProcessor();
                processor.TransformString += (s, e) => { e.Value = Accenter.Transform(e.Value); };
                processor.Transform(inputStream, outputStream);
            }
        }
    }
}
