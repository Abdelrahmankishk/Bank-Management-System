using Bank_Management_System.Configurations;
using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System;

    public class AppDbContext :DbContext
    {
    public DbSet<Branch> branches {  get; set; }
    public DbSet<Manager> managers { get; set; }
    public DbSet<Account> accounts { get; set; }
    public DbSet<Customer> customers { get; set; }
    public DbSet<Transaction> transactions { get; set; }

    public DbSet<CustomerAccount> customersAccount { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.;Database=BankManagementSysrem;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BranchConfiguration());
        modelBuilder.ApplyConfiguration(new ManagerConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new CustomersConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionConfiguration());

        #region Account Customer Many to Many
        #endregion
        modelBuilder.Entity<CustomerAccount>()
                    .HasKey(ca => new { ca.cutomerId, ca.accountId });

        modelBuilder.Entity<CustomerAccount>()
                    .Property(ca=>ca.OwnerShipDate)
                    .HasDefaultValueSql("GETDATE()");
    }
    
}

