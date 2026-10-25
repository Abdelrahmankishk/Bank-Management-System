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

        #region Data
        builder.HasData(
            new Customer { Id = 1, FullName = "John Doe", Address = "789 Oak Rd", Email = "john@example.com", PhoneNumber = "555-3333", NationalID = "NAT-1001", Type = CustomerType.Individual, DateOfBirth = new DateOnly(1985, 4, 12) },
            new Customer { Id = 2, FullName = "Acme Corp", Address = "100 Industrial Pkwy", Email = "contact@acme.com", PhoneNumber = "555-4444", NationalID = "NAT-2002", Type = CustomerType.Organization, DateOfBirth = new DateOnly(2010, 1, 1) }
        );
        #endregion
    }
}

