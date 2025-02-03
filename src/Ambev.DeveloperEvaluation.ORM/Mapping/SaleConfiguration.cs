using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.SalesNumber)
               .UseIdentityColumn();


        builder.HasMany(s => s.SaleItems)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(s => s.Customer)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(s => s.Subsidiary)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);
    }
}
