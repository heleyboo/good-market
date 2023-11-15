using GoodMarket.Models;

namespace GoodMarket.Context.Fluent;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
        builder.Property(b => b.Description).HasMaxLength(500);
        builder.Property(b => b.IconUrl).HasMaxLength(2000);

        // Additional configurations can be added as needed
    }
}

public class EditionConfiguration : IEntityTypeConfiguration<Edition>
{
    public void Configure(EntityTypeBuilder<Edition> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);

        // Define the relationship with Brand
        builder.HasOne(e => e.Brand)
            .WithMany(b => b.Editions)
            .HasForeignKey(e => e.BrandId)
            .IsRequired();

        // Additional configurations can be added as needed
    }
}
