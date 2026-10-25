using Bank_Management_System.Models;
using Bank_Management_System.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");

        builder.HasKey(a => a.Id);
        builder.HasAlternateKey(a => a.AccountNumber);

        builder.Property(a => a.AccountNumber)
            .IsRequired()
            .HasMaxLength(30);
        builder.Property(a => a.CurrentBalance)
            .HasColumnName("Balance")
            .HasColumnType("decimal(18,2)");

        #region Account Transaction one to many Relationship
        builder.HasMany(a => a.transactions)
               .WithOne(t => t.account)
               .HasForeignKey(a => a.AccountId);
        #endregion

        #region Data
        builder.HasData(
            new Account { Id = 1, AccountNumber = "ACC-9001-2026", CurrentBalance = 15430.75, accountType = AccountType.Savings, OpeningDate = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc), BranchId = 1 },
            new Account { Id = 2, AccountNumber = "ACC-9002-2026", CurrentBalance = 2450.00, accountType = AccountType.Current, OpeningDate = new DateTime(2025, 6, 20, 0, 0, 0, DateTimeKind.Utc), BranchId = 2 }
        );
        #endregion
    }
}

