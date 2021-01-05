using System;
using System.IO;
using System.Collections.Generic;

namespace UsingFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = FindFiles("stores");
            Console.WriteLine(Directory.GetCurrentDirectory());
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }

        static IEnumerable<string> FindFiles(string folderName)
        {
            List<string> salesFiles = new List<string>();
    
            var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);
    
            foreach (var file in foundFiles)
            {
                if (file.EndsWith("sales.json"))
                {
                    salesFiles.Add(file);
                }
            }
    
            return salesFiles;
        }
    }

}
