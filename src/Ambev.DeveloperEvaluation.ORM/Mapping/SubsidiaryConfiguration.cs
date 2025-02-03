using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SubsidiaryConfiguration : IEntityTypeConfiguration<Subsidiary>
{
    public void Configure(EntityTypeBuilder<Subsidiary> builder)
    {
        builder.ToTable("Subsidiaries");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
        builder.Property(s => s.CompanyIdentifierCode).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Address).IsRequired().HasMaxLength(200);
        builder.Property(s => s.Phone).IsRequired().HasMaxLength(20);
        builder.Property(s => s.CreatedAt).IsRequired();
        builder.Property(s => s.UpdatedAt);
    }
}