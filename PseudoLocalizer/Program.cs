using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using PseudoLocalizer.Core.Tests;
using System.IO;
using PseudoLocalizer.Core;

namespace PseudoLocalizer
{
    class Program
    {
        static void Main(string[] args)
        {
            //new ResxProcessorTests().ShouldAddFunnyAccentsWhenTransformingWithTheAccenterTransformation();

            var inputFileName = @"c:\temp\LanguageResources.resx";

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
