
public enum TransactionType { CREDIT, DEBIT }
public class Transaction : BaseEntity
{
    public string Title { get; set; } = null!;
    public TransactionType Type { get; set; }
    public StatusTransaction Status { get; set; }
    public decimal Amount { get; set; }
    public Guid? InvoiceId { get; set; }
    public string? ErrorMessage { get; set; }
    public Guid WalletId { get; set; }
}

