using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(c => c.MainName).IsRequired().HasMaxLength(100);
        builder.Property(c => c.ContractName).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Phone).IsRequired().HasMaxLength(20);
        builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
        builder.Property(c => c.CreatedAt).IsRequired();
        builder.Property(c => c.UpdatedAt);

        builder.HasMany(c => c.Ratings)
               .WithOne(r => r.Customer)
               .HasForeignKey(r => r.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}