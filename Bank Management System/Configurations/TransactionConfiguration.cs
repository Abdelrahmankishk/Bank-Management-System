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
public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transactions");

        builder.HasKey(t => t.TransactionNumber);

        builder.Property(t => t.Date)
            .HasDefaultValueSql("GETDATE()");

        builder.Property(a => a.Amount)
            .HasColumnType("decimal(18,2)");

        builder.HasData(
            new Transaction { TransactionNumber = 1, Date = new DateTime(2026, 1, 10, 10, 30, 0, DateTimeKind.Utc), Amount = 500.00, Note = "Initial Deposit", Type = TransactionType.Deposit, AccountId = 1 },
            new Transaction { TransactionNumber = 2, Date = new DateTime(2026, 2, 1, 14, 15, 0, DateTimeKind.Utc), Amount = 150.50, Note = "ATM Withdrawal", Type = TransactionType.Withdrawal, AccountId = 2 }
        );
    }
}

