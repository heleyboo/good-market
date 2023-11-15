using GoodMarket.Models;

namespace GoodMarket.Context.Fluent;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FormFieldConfiguration : IEntityTypeConfiguration<FormField>
{
    public void Configure(EntityTypeBuilder<FormField> builder)
    {
        builder.ToTable("FormFields"); // Set the table name if needed

        builder.HasKey(ff => ff.Id); // Assuming there is an Id property

        builder.Property(ff => ff.Label).HasMaxLength(255); // Set the maximum length for the label
        builder.Property(ff => ff.Name).IsRequired().HasMaxLength(50); // Set the maximum length and mark it as required
        builder.Property(ff => ff.Value).HasMaxLength(255); // Set the maximum length for the value
        builder.Property(ff => ff.Placeholder).HasMaxLength(255); // Set the maximum length for the placeholder
        builder.Property(ff => ff.ApiUrl).HasMaxLength(255); // Set the maximum length for the API URL

        builder.Property(ff => ff.Type)
            .IsRequired()
            .HasConversion(
                v => v.ToString(), // Convert enum to string for storage
                v => (FormFieldType)Enum.Parse(typeof(FormFieldType), v)); // Convert string back to enum on retrieval

        builder.Property(ff => ff.SortOrder).IsRequired();
        builder.Property(ff => ff.IsRequired).IsRequired();
        builder.Property(ff => ff.IsHidden).IsRequired();
        builder.Property(ff => ff.IsDisabled).IsRequired();
        
        builder.HasOne<Form>(ff => ff.Form)
                    .WithMany(f => f.FormFields)
                    .HasForeignKey(ff => ff.FormId)
                    .OnDelete(DeleteBehavior.Cascade);
    }
}
