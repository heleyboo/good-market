using GoodMarket.Models;
using GoodMarket.Models.VietnameseAdministrativeUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Context.Fluent;

public class CategoryConfiguration: IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> modelBuilder)
    {
        modelBuilder
            .ToTable("Categories") // Set the table name
            .HasKey(c => c.Id); // Set the primary key

        modelBuilder
            .Property(c => c.Id)
            .IsRequired()
            .ValueGeneratedOnAdd(); // Set the CategoryId property as required and auto-generated

        modelBuilder
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(255); // Set the CategoryName property as required and with a max length of 255 characters

        modelBuilder
            .HasMany(c => c.Subcategories) // Configure the relationship with Subcategories
            .WithOne()
            .HasForeignKey(c => c.ParentCategoryId);
        
        modelBuilder
            .HasIndex(c => c.Code) // Add unique constraint on 'Code'
            .IsUnique();

        modelBuilder
            .Property(c => c.ImageUrl)
            .HasMaxLength(255); 
        
        modelBuilder
            .Property(c => c.ParentCategoryId)
            .IsRequired(false); 
        
        modelBuilder
            .HasOne<Category>(w => w.ParentCategory)
            .WithMany(d => d.Subcategories)
            .HasForeignKey(w => w.ParentCategoryId);
    }
}