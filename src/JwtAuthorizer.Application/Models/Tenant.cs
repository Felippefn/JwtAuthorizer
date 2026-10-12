public class Tenant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public StatusTenant Status { get; set; }
    public Guid OwnerId { get; set; }
    public string BillingEmail { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

