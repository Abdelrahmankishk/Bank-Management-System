using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}

