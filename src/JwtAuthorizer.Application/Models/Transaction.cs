
public enum TransactionType { Credit, Debit }
public class Transaction : BaseEntity
{
    public string Title { get; private set; } = null!;
    public TransactionType Type { get; private set; }
    public StatusTransaction Status { get; set; }
    public decimal Amount { get; private set; }
    public Guid? InvoiceId { get; set; }
    public string? ErrorMessage { get; set; }
    public Guid WalletId { get; private set; }
}

