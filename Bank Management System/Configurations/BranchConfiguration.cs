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

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("Branches");

        builder.HasKey(x => x.Code);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.Address)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.PhoneNumber)
               .IsRequired()
               .HasMaxLength(100);

        #region Branch Account one to many Relationship
        builder.HasMany(b => b.accounts)
            .WithOne(a => a.branch)
            .HasForeignKey(b => b.BranchId)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region Data
        builder.HasData(
            new Branch { Code = 1, Name = "Main Branch", Address = "123 Financial St", PhoneNumber = "555-0100" },
            new Branch { Code = 2, Name = "Downtown Branch", Address = "456 Market Ave", PhoneNumber = "555-0200" }
        );
        #endregion
    }
}

