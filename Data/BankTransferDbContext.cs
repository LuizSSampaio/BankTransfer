using BankTransfer.Models;
using Microsoft.EntityFrameworkCore;

namespace BankTransfer.Data;

public class BankTransferDbContext : DbContext
{
    public BankTransferDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Account> Accounts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
            .HasIndex(u => u.Identifier)
            .IsUnique();
        modelBuilder.Entity<Account>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Account>()
            .HasDiscriminator<string>("AccountType")
            .HasValue<User>("User")
            .HasValue<Store>("Store");
    }
}