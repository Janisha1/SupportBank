using System.Globalization;
using NLog;
namespace SupportBank;

public class CSVParser
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();


    public Ledger Parse()
    {
        Logger.Info("SupportBank CSVParser.Parse() started successfully.");
        string filePath = @"./data/Transactions2014.csv";
        //string filePath = @"./data/DodgyTransactions2015.csv";
        Ledger ledger = new Ledger();

        if (File.Exists(filePath))
        {
            StreamReader reader = new StreamReader(File.OpenRead(filePath));
            int rowCount = 0;

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line != null)
                {
                    var values = line.Split(',');
                    rowCount++;
                    if (rowCount == 1)
                    {
                        List<string> headerLine = new List<string>(values);
                        continue;
                    }

                    string payerName = values[1];
                    string payeeName = values[2];

                    Person payer = new Person(payerName);
                    Person payee = new Person(payeeName);

                    DateTime transactionDate;
                    if (!DateTime.TryParseExact(
                        values[0],
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out transactionDate))
                    {
                        Logger.Error($"Invalid date format in line {rowCount}: {values[0]}");
                        Console.WriteLine($"Invalid date format in line {rowCount}: {values[0]}");
                        continue;
                    }

                    string amountStr = values[4];
                    if (!decimal.TryParse(amountStr, out decimal amount))
                    {
                        Logger.Error($"Invalid amount format in line {rowCount}: {amountStr}");
                        Console.WriteLine($"Invalid amount format in line {rowCount}: {amountStr}");
                        continue;
                    }

                    var transaction = new Transaction(
                        transactionDate,
                        payer,
                        payee,
                        values[3],
                        amount
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


