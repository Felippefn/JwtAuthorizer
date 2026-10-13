public class Wallet : BaseEntity
{
    public decimal Balance { get; set; } 
    public Guid UserId { get; set; }
    public string Currency { get; set; } = "BRL";
    public List<Transaction> Transactions { get; set; } = new();
}

