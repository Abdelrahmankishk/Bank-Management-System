using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Configurations;

public class CustomersConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.Property(c => c.NationalID)
              .IsRequired()
              .HasMaxLength(14);
        builder.HasIndex(c => c.NationalID)
            .IsUnique();

        builder.Property(c => c.FullName)
            .IsRequired()
            .HasColumnName("Name");

        builder.Property(c => c.Email)
            .IsRequired();

        builder.Property(c => c.PhoneNumber)
            .IsRequired();

    }
}

