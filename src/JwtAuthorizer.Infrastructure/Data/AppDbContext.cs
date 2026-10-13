using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<User> Users => Set<User>();
    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<Wallet> Wallets => Set<Wallet>();
    public DbSet<Transaction> Transactions => Set<Transaction>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(u =>
        {
            u.HasIndex(x => x.Email).IsUnique();
            u.Property(x => x.Role).HasConversion<string>();
            u.HasOne<Tenant>()
             .WithMany()
             .HasForeignKey(x => x.TenantId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Tenant>(t =>
        {
            t.HasOne<User>()
             .WithMany()
             .HasForeignKey(x => x.OwnerId);
        });

        modelBuilder.Entity<Wallet>(w =>
        {
            w.Property(x => x.Balance).HasPrecision(18, 2);
            w.Property(x => x.Currency).HasMaxLength(3);
            w.HasIndex(x => x.UserId).IsUnique();
            w.HasOne<User>()
             .WithOne()
             .HasForeignKey<Wallet>(x => x.UserId)
             .OnDelete(DeleteBehavior.Restrict);
            w.HasMany(x => x.Transactions)
             .WithOne()
             .HasForeignKey(tr => tr.WalletId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Transaction>(t =>
        {
            t.Property(x => x.Amount).HasPrecision(18, 2);
            t.Property(x => x.Title).HasMaxLength(200);
        });
    }
}
