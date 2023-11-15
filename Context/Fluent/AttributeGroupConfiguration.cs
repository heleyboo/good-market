using GoodMarket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Attribute = GoodMarket.Models.Attribute;

namespace GoodMarket.Context.Fluent;

public class AttributeGroupConfiguration : IEntityTypeConfiguration<AttributeGroup>
{
    public void Configure(EntityTypeBuilder<AttributeGroup> builder)
    {
        builder.HasKey(ag => ag.Id);

        builder.HasIndex(ag => ag.Code).IsUnique(); // Enforce uniqueness on Code

        // Other configurations, if needed
    }
}

public class AttributeConfiguration : IEntityTypeConfiguration<Attribute>
{
    public void Configure(EntityTypeBuilder<Attribute> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasIndex(a => a.Code).IsUnique(); // Enforce uniqueness on Code

        builder.HasOne(a => a.AttributeGroup)
            .WithMany(ag => ag.Attributes)
            .HasForeignKey(a => a.AttributeGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        // Other configurations, if needed
    }
}

public class AttributeOptionConfiguration : IEntityTypeConfiguration<AttributeOption>
{
    public void Configure(EntityTypeBuilder<AttributeOption> builder)
    {
        builder.HasKey(ao => ao.Id);

        builder.HasIndex(ao => ao.Code).IsUnique(); // Enforce uniqueness on Code

        builder.HasOne(ao => ao.Attribute)
            .WithMany(a => a.AttributeOptions)
            .HasForeignKey(ao => ao.AttributeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Other configurations, if needed
    }
}

public class CategoryAttributeConfiguration : IEntityTypeConfiguration<CategoryAttribute>
{
    public void Configure(EntityTypeBuilder<CategoryAttribute> builder)
    {
        builder.HasKey(ca => new { ca.CategoryId, ca.AttributeId });

        // Other configurations, if needed
    }
}