namespace SupportBank;

public class Ledger
{
    private List<Transaction> transactions = new List<Transaction>();

    public void AddTransaction(Transaction transaction)
    {
        transactions.Add(transaction);
    }

    public void PrintLedger()
    {
        Console.WriteLine("Transaction Ledger:");
        foreach (Transaction transaction in transactions)
        {
            Console.WriteLine($"{transaction.Timestamp}: {transaction.Payer.Name} paid {transaction.Amount:C} to {transaction.Payee.Name}");
        }
    }
}