namespace SupportBank;

public class Transaction
{
    public DateTime Timestamp { get; set; }
    public Person Payer { get; set; }
    public Person Payee { get; set; }
    public decimal Amount { get; set; }
}
