﻿using System;
using System.Globalization;
using SupportBank;

/* Logging */
using NLog;
using NLog.Config;
using NLog.Targets;
var config = new LoggingConfiguration();
var target = new FileTarget { FileName = @"C:\Work\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
config.AddTarget("File Logger", target);
config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
LogManager.Configuration = config;

/* Program */

var parser = new CSVParser();
var ledger = parser.Parse();
var report = new Report();


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
Console.WriteLine("Choose a report:");
Console.WriteLine("1. List All");
Console.WriteLine("2. List [Account]");

string choice = Console.ReadLine();
if(!string.IsNullOrWhiteSpace(choice))
{
    if (choice == "1")
    {
        Dictionary<string, decimal> balances = CalculateBalances(ledger);
        report.ListAll(balances);
    }
    else if (choice == "2")
    {
        Console.Write("Enter account name: ");
        string accountName = Console.ReadLine();
        Dictionary<string, decimal> balances = CalculateBalances(ledger);
        if (!balances.ContainsKey(accountName))
        {
            Console.WriteLine($"Name not found {accountName}");
        } 
        else
        {
        report.ListAccount(ledger, accountName);
        }    
    }
}
else
{
    Console.WriteLine("Invalid choice");
}