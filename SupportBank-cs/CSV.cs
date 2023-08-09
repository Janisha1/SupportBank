using System;
using System.Collections.Generic;
using System.IO;

namespace SupportBank

class CSVParser
{
    public static void Main()
    {
        string filePath = @"C:\Users\Koushik\Desktop\Questions\ConsoleApp\Data.csv";
        StreamReader reader = null;

        if (File.Exists(filePath))
        {
            reader = new StreamReader(File.OpenRead(filePath));
            List<List<string>> rows = new List<List<string>>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                List<string> rowValues = new List<string>(values);
                rows.Add(rowValues);
            }

            foreach (var row in rows)
            {
                foreach (var value in row)
                {
                    Console.Write(value + "\t");
                }
                Console.WriteLine(); // Move to the next line for the next row
            }
        }
        else
        {
            Console.WriteLine("File doesn't exist");
        }

        Console.ReadLine();
    }
}
