using GoodMarket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Context.Fluent;

public class FormConfiguration : IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.ToTable("Forms");

        builder.HasKey(f => f.Id);
        
        builder.Property(ff => ff.Name).IsRequired().HasMaxLength(50); // Set the maximum length and mark it as required

        // Other property configurations...

        // New configuration for the relationship
        builder.HasMany<FormField>(f => f.FormFields)
            .WithOne(ff => ff.Form)
            .HasForeignKey(ff => ff.FormId);
        
        builder
            .HasOne<Category>(f => f.Category)
            .WithOne(c => c.Form)
            .HasForeignKey<Category>(ct => ct.FormId);
    }
}
