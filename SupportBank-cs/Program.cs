using System;
using System.Globalization;
using SupportBank;

var parser = new CSVParser();
var ledger = parser.Parse();

static Dictionary<string, decimal> CalculateBalances(Ledger ledger)
    {
        Dictionary<string, decimal> balances = new Dictionary<string, decimal>();

        foreach (Transaction transaction in ledger.Transactions)
        {
            if (!balances.ContainsKey(transaction.Payer.Name))
            {
                balances[transaction.Payer.Name] = 0;
            }
            if (!balances.ContainsKey(transaction.Payee.Name))
            {
                balances[transaction.Payee.Name] = 0;
            }

            balances[transaction.Payer.Name] -= transaction.Amount;
            balances[transaction.Payee.Name] += transaction.Amount;

        }

        return balances;
    }

Console.WriteLine("Welcome to SupportBank!");
Console.WriteLine("Choose an option:");
Console.WriteLine("1. List All");
Console.WriteLine("2. List [Account]");

string choice = Console.ReadLine();

if (choice == "1")
{
    Dictionary<string, decimal> balances = CalculateBalances(ledger);
    PrintAccountsAndBalances(balances);
}
else if (choice == "2")
{
    Console.Write("Enter account name: ");
    string accountName = Console.ReadLine();
    PrintTransactionsForAccount(ledger, accountName);
}
else
{
    Console.WriteLine("Invalid choice");
}


static void PrintAccountsAndBalances(Dictionary<string, decimal> balances)
{
    Console.WriteLine("List of Accounts and Balances:");
    foreach (var personName in balances.Keys)
    {
        decimal balance = balances[personName];
        Console.WriteLine($"{personName}: {balance:C}");
    }
}

static void PrintTransactionsForAccount(Ledger ledger, string accountName)
{
    Console.WriteLine($"Transactions for account: {accountName}");

    foreach (Transaction transaction in ledger.Transactions)
    {
        if (transaction.Payer.Name == accountName || transaction.Payee.Name == accountName)
        {
            Console.WriteLine($"Date: {transaction.Timestamp}, Payer: {transaction.Payer.Name}, Payee: {transaction.Payee.Name}, Amount: {transaction.Amount:C}, Narrative: {transaction.Narrative}");
        }
        else 
        {
            Console.WriteLine($"Name not found {accountName}");
            return;
        }
    }
}






