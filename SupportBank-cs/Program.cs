using System;
using System.Globalization;
using SupportBank;

var parser = new CSVParser();
var ledger = parser.Parse();

Dictionary<string, decimal> balances = CalculateBalances(ledger);

PrintAccountsAndBalances(balances);

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

     static void PrintAccountsAndBalances(Dictionary<string, decimal> balances)
        {
            Console.WriteLine("List of Accounts and Balances:");
            foreach (var personName in balances.Keys)
            {
                decimal balance = balances[personName];
                Console.WriteLine($"{personName}: {balance:C}");
            }
        }






