using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Configurations;

public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder.ToTable("Managers");

        builder.HasKey(x => x.Id);

        builder.Property(m => m.FullName)
               .IsRequired()
               .HasColumnName("Name")
               .HasMaxLength(100);

        builder.Property(m => m.PhoneNumber)
               .IsRequired()
               .HasMaxLength(100);

        #region Branch Manager One to One Relationship
        builder.HasOne(m => m.Branch)
            .WithOne(b => b.manager)
            .HasForeignKey<Manager>(m => m.BranchId)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region Data
        builder.HasData(
            new Manager { Id = 1, FullName = "Alice Smith", Email = "alice.smith@bank.com", PhoneNumber = "555-1111", HireDate = new DateOnly(2020, 5, 10), BranchId = 1 },
            new Manager { Id = 2, FullName = "Bob Jones", Email = "bob.jones@bank.com", PhoneNumber = "555-2222", HireDate = new DateOnly(2021, 8, 15), BranchId = 2 }
        );
        #endregion
    }
}

