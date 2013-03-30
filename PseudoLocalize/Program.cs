﻿namespace PseudoLocalizer
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Security;
    using PseudoLocalizer.Core;

    /// <summary>
    /// Main class for the pseudo-localizer console application.
    /// </summary>
    public class Program
    {
        private List<string> _inputFiles = new List<string>();

        public Program()
        {
            UseDefaultOptions = true;
        }

        public bool UseDefaultOptions { get; set; }

        public bool EnableExtraLength { get; set; }

        public bool EnableAccents { get; set; }

        public bool EnableBrackets { get; set; }

        public bool EnableMirror { get; set; }

        public bool EnableUnderscores { get; set; }

        public bool HasInputFiles
        {
            get { return _inputFiles.Count > 0; }
        }

        public static void Main(string[] args)
        {
            var instance = new Program();
            if (ParseArguments(args, instance))
            {
                instance.Run();
            }
            else
            {
                Console.WriteLine("Usage: PseudoLocalize [/l] [/a] [/b] [/m] [/u] file [file...]");
                Console.WriteLine("Generates pseudo-localized versions of the specified input file(s).");
                Console.WriteLine();
                Console.WriteLine("The input files must be resource files in Resx file format.");
                Console.WriteLine("The output will be written to a file next to the original, with .qps-ploc");
                Console.WriteLine("appended to its name. For example, if the input file is X:\\Foo\\Bar.resx,");
                Console.WriteLine("then the output file will be X:\\Foo\\Bar.qps-ploc.resx.");
                Console.WriteLine();
                Console.WriteLine("Options:");
                Console.WriteLine("  /l  Make all words 30% longer, to ensure that there is room for translations.");
                Console.WriteLine("  /a  Add accents on all letters so that non-localized text can be spotted.");
                Console.WriteLine("  /b  Add brackets to show the start and end of each localized string.");
                Console.WriteLine("      This makes it possible to spot cut off strings.");
                Console.WriteLine("  /m  Reverse all words (\"mirror\").");
                Console.WriteLine("  /u  Replace all characters with underscores.");
                Console.WriteLine("The default options, if none are given, are: /l /a /b.");
            }
        }

        public void ClearInputFiles()
        {
            _inputFiles.Clear();
        }

        public void AddInputFile(string filePath)
        {
            _inputFiles.Add(filePath);
        }

        private static bool ParseArguments(string[] args, Program instance)
        {
            instance.ClearInputFiles();
            instance.UseDefaultOptions = true;
            instance.EnableAccents = false;
            instance.EnableExtraLength = false;
            instance.EnableBrackets = false;
            instance.EnableMirror = false;
            instance.EnableUnderscores = false;

            foreach (var arg in args)
            {
                if (arg.StartsWith("/", StringComparison.Ordinal) || arg.StartsWith("-", StringComparison.Ordinal))
                {
                    switch (arg.Substring(1).ToUpperInvariant())
                    {
                        case "L":
                            instance.EnableExtraLength = true;
                            instance.UseDefaultOptions = false;
                            break;

                        case "A":
                            instance.EnableAccents = true;
                            instance.UseDefaultOptions = false;
                            break;

                        case "B":
                            instance.EnableBrackets = true;
                            instance.UseDefaultOptions = false;
                            break;

                        case "M":
                            instance.EnableMirror = true;
                            instance.UseDefaultOptions = false;
                            break;

                        case "U":
                            instance.EnableUnderscores = true;
                            instance.UseDefaultOptions = false;
                            break;

                        default:
                            Console.WriteLine("ERROR: Unknown option \"{0}\".", arg);
                            return false;
                    }
                }
                else
                {
                    instance.AddInputFile(arg);
                }
            }

            return instance.HasInputFiles;
        }

        private void Run()
        {
            foreach (var filePath in _inputFiles)
            {
                ProcessResxFile(filePath);
            }
        }

        private void ProcessResxFile(string inputFileName)
        {
            try
            {
                var outputFileName = Path.Combine(Path.GetDirectoryName(inputFileName), Path.GetFileNameWithoutExtension(inputFileName) + ".qps-ploc" + Path.GetExtension(inputFileName));

                using (var inputStream = new FileStream(inputFileName, FileMode.Open, FileAccess.Read))
                using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                {
                    var processor = new ResxProcessor();
                    if (EnableExtraLength || UseDefaultOptions)
                    {
                        processor.TransformString += (s, e) => { e.Value = ExtraLength.Transform(e.Value); };
                    }

                    if (EnableAccents || UseDefaultOptions)
                    {
                        processor.TransformString += (s, e) => { e.Value = Accents.Transform(e.Value); };
                    }
                    
                    if (EnableBrackets || UseDefaultOptions)
                    {
                        processor.TransformString += (s, e) => { e.Value = Brackets.Transform(e.Value); };
                    }
                    
                    if (EnableMirror)
                    {
                        processor.TransformString += (s, e) => { e.Value = Mirror.Transform(e.Value); };
                    }
                    
                    if (EnableUnderscores)
                    {
                        processor.TransformString += (s, e) => { e.Value = Underscores.Transform(e.Value); };
                    }
                    
                    processor.Transform(inputStream, outputStream);
                }

                Console.WriteLine("The file {0} was written successfully.", outputFileName);
            }
            catch (Exception ex)
            {
                if (ex is PathTooLongException ||
                    ex is FileNotFoundException ||
                    ex is DirectoryNotFoundException ||
                    ex is IOException ||
                    ex is SecurityException)
                {
                    Console.WriteLine(ex.Message);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
