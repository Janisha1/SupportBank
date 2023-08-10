namespace SupportBank;
using System.Globalization;

public class CSVParser
{
    public Ledger Parse()
    {
        string filePath = @"./Transactions2014.csv";
        Ledger ledger = new Ledger();

        if (File.Exists(filePath))
        {
            StreamReader reader = new StreamReader(File.OpenRead(filePath));
            int rowCount = 0;

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if(line != null)
                {
                    var values = line.Split(',');
                    rowCount ++;
                    if(rowCount == 1)
                    {
                        List<string> headerLine = new List<string>(values);
                        continue;
                    }

                    string payerName = values[1];
                    string payeeName = values[2];

                    Person payer = new Person(payerName);
                    Person payee = new Person(payeeName);

                    var transaction = new Transaction
                    (DateTime.Parse(values[0], new CultureInfo("en-GB"))
                    ,payer
                    ,payee
                    ,values[3]
                    ,decimal.Parse(values[4])
                    );
                    ledger.AddTransaction(transaction);
                }
            }
        }
        else
        {
            Console.WriteLine("File doesn't exist");
        }

        return ledger;
    }
}

