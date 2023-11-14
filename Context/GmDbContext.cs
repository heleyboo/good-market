using GoodMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodMarket.Context;

public class GmDbContext: DbContext
{
    private readonly IConfiguration _configuration;

    public GmDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgresDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .ToTable("posts")
            .HasKey(p => p.Id);
        
        modelBuilder.Entity<Category>()
            .ToTable("Categories") // Set the table name
            .HasKey(c => c.Id); // Set the primary key

        modelBuilder.Entity<Category>()
            .Property(c => c.Id)
            .IsRequired()
            .ValueGeneratedOnAdd(); // Set the CategoryId property as required and auto-generated

        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(255); // Set the CategoryName property as required and with a max length of 255 characters

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Subcategories) // Configure the relationship with Subcategories
            .WithOne()
            .HasForeignKey(c => c.ParentCategoryId);
        
        modelBuilder.Entity<Category>()
            .HasIndex(c => c.Code) // Add unique constraint on 'Code'
            .IsUnique();

        modelBuilder.Entity<Category>()
            .Property(c => c.ImageUrl)
            .HasMaxLength(255); 
        
        modelBuilder.Entity<Category>()
            .Property(c => c.ParentCategoryId)
            .IsRequired(false); 
        
        modelBuilder.Entity<Category>()
            .HasOne<Category>(w => w.ParentCategory)
            .WithMany(d => d.Subcategories)
            .HasForeignKey(w => w.ParentCategoryId);

        // Additional configurations as needed

        base.OnModelCreating(modelBuilder);
    }
}