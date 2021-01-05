using System;
using System.IO;
using System.Collections.Generic;

namespace UsingFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        
        static IEnumerable<string> FindFiles(string folderName)
        {
            List<string> salesFiles = new List<string>();

            var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

            foreach(var file in foundFiles)
            {
                //The file name will contain the ful path, so only check the end of it
                if(file.EndsWith("sales.jason"))
                {
                    salesFiles.Add(file);
                }
            }
            return salesFiles;
        }
    }

}
