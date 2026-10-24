using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}

