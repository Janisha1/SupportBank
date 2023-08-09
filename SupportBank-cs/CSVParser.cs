namespace SupportBank;

public class CSVParser
{
    public void Parse()
    {
        string filePath = @"./Transactions2014.csv";
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
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("File doesn't exist");
        }

        Console.ReadLine();
    }
}
