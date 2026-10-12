public class Wallet : BaseEntity
{
    public decimal Balance { get; set; } 
    public Guid UserId { get; set; }
    public List<Transaction> Transactions { get; set; }
}

