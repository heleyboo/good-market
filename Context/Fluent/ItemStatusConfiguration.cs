using GoodMarket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Context.Fluent;

public class ItemStatusConfiguration : IEntityTypeConfiguration<ItemStatus>
{
    public void Configure(EntityTypeBuilder<ItemStatus> builder)
    {
        builder.ToTable("ItemStatuses");

        builder.HasKey(f => f.Id);
        
        builder.Property(ff => ff.Name).IsRequired().HasMaxLength(255);
    }
}
