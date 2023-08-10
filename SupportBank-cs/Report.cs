namespace SupportBank;

public class Report
{
    public void ListAll(Dictionary<string, decimal> balances)
    {
        Console.WriteLine("List of Accounts and Balances:");
        foreach (var personName in balances.Keys)
        {
            decimal balance = balances[personName];
            Console.WriteLine($"{personName}: {balance:C}");
        }
    }
    public void ListAccount(Ledger ledger, string accountName)
    {
        Console.WriteLine($"Transactions for account: {accountName}");

        foreach (Transaction transaction in ledger.Transactions)
        {
            if (transaction.Payer.Name == accountName || transaction.Payee.Name == accountName)
            {
                Console.WriteLine($"Date: {transaction.Timestamp}, Payer: {transaction.Payer.Name}, Payee: {transaction.Payee.Name}, Amount: {transaction.Amount:C}, Narrative: {transaction.Narrative}");
            }
        }
    }
}