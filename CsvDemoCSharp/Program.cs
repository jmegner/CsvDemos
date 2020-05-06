using System;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

// TextFieldParser class reference:
// https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualbasic.fileio.textfieldparser?redirectedfrom=MSDN&view=netcore-3.1
//
// for a more powerful library, there's the 3rd party library CsvHelper available via nuget
// nuget link: https://www.nuget.org/packages/CsvHelper
// project site: https://joshclose.github.io/CsvHelper/

namespace CsvDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("begin");

            foreach(var arg in args)
            {
                Console.WriteLine($"reading file '{arg}'");

                using var parser = new TextFieldParser(arg);
                parser.SetDelimiters(",");

                int lineNum = 0;

                while(!parser.EndOfData)
                {
                    lineNum++;

                    var fields = parser.ReadFields();

                    // at this point, could just do the following to print out the fields, separated again by commas:
                    // Console.WriteLine(string.Join(",", fields));

                    // but let's get a little more fancy; make empty fields more obvious and have bigger separators
                    var fancyFields = fields.Select(f => string.IsNullOrEmpty(f) ? "[EMPTY]" : f);
                    Console.WriteLine($"    line {lineNum:000}: {string.Join("  |  ", fancyFields)}");
                }
            }

            Console.WriteLine("done");
        }
    }
}
