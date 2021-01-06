using System;
using System.IO;
using System.Collections.Generic;

namespace UsingFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string storesDirectory = Path.Combine(currentPath, "stores");
            string salesTotalsDir = Path.Combine(currentPath, "salesTotalDir");

            Directory.CreateDirectory(salesTotalsDir);
            //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //string userPath = $"C:{Path.DirectorySeparatorChar}User";
            var salesfiles = FindFiles(storesDirectory);

            File.WriteAllText(Path.Combine(salesTotalsDir,"totals.txt"), String.Empty);
            Console.WriteLine(currentPath);
 
            //string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";
//
            //FileInfo info = new FileInfo(fileName);
//
            //Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}"); // And many more
        }

        static IEnumerable<string> FindFiles(string folderName)
        {
            List<string> salesFiles = new List<string>();
    
            var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);
    
            foreach (var file in foundFiles)
            {
                var extension = Path.GetExtension(file);

                if (extension == ".json")
                {
                    salesFiles.Add(file);
                }
            }
    
            return salesFiles;
        }
    }

}
