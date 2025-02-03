using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.ToTable("Ratings");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.CustomerId).IsRequired();
        builder.Property(r => r.ProductId).IsRequired();
        builder.Property(r => r.Rate).IsRequired();

        builder.HasOne(r => r.Customer)
               .WithMany(c => c.Ratings)
               .HasForeignKey(r => r.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Product)
               .WithMany(p => p.Ratings)
               .HasForeignKey(r => r.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}