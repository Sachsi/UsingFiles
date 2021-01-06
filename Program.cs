using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

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
            var salesTotal = CalculateSalesTotal(salesfiles);

            if(Directory.Exists(Path.Combine(salesTotalsDir,"totals.txt")) == true)
            {
                File.WriteAllText(Path.Combine(salesTotalsDir,"totals.txt"), String.Empty);
            }

            File.AppendAllText(Path.Combine(salesTotalsDir,"totals.txt"), $"{salesTotal}{Environment.NewLine}");
            Console.WriteLine(currentPath);
 
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
        static double CalculateSalesTotal(IEnumerable<string> salesFiles)
        {
            double salesTotal = 0;
            //read files loop
            foreach(var file in salesFiles)
            {
                string salesJson = File.ReadAllText(file);
                //Parse the contents as JSON
                SalesData data = JsonConvert.DeserializeObject<SalesData>(salesJson);
                //Add the amount found in the total field to the salesTotal varaible
                salesTotal += data.Total;
            }
            return salesTotal;
        }

        class SalesData
        {
            public double Total{ get; set;}
        }
    }


}
