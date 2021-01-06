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
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string userPath = $"C:{Path.DirectorySeparatorChar}User";

            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine($"This is the path to My Documents: " + docPath);
            Console.WriteLine("This is the user path: " + userPath);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

            string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";

            FileInfo info = new FileInfo(fileName);

            Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}"); // And many more
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
