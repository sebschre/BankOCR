using System;
using System.IO;
using System.Collections.Generic;

namespace OCRNamespace
{
    public class Program
    {
        public static void Main()
        {
            var textFilePath = "ocr1.txt";
            var linesInTextFile = new List<string>(File.ReadAllLines(textFilePath));
            var ocrInterpreter = new OCRInterpreter(
                new TokenLineCreatorOCR(),
                new TokenCreatorOCR(),
                new TokenInterpreterOCR()
            );
            var parsedLineList = ocrInterpreter.Parse(linesInTextFile);
            foreach (var parsedLine in parsedLineList)
                Console.WriteLine($"{parsedLine}");
        }
    }
}