namespace SupportBank;

public class Ledger
{
    public List<Transaction> Transactions {get;} = new List<Transaction>();

    public void AddTransaction(Transaction transaction)
    {
        Transactions.Add(transaction);
    }

    public void PrintLedger()
    {
        Console.WriteLine("Transaction Ledger:");
        foreach (Transaction transaction in Transactions)
        {
            Console.WriteLine($"{transaction.Timestamp}: {transaction.Payer.Name} paid {transaction.Amount:C} to {transaction.Payee.Name}");
        }
    }
}