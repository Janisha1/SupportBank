namespace SupportBank;

public class Transaction
{
    public DateTime Timestamp { get; }
    public Person Payer { get; }
    public Person Payee { get; }
    
    public string Narrative { get; }
    public decimal Amount { get; set; }

    public Transaction (DateTime Timestamp, Person Payer, Person Payee, string Narrative, decimal Amount )
    {
        this.Timestamp = Timestamp;
        this.Payer = Payer;
        this.Payee = Payee;
        this.Narrative = Narrative;
        this.Amount = Amount;
    }
}
