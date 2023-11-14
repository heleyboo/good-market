using GoodMarket.Models;
using GoodMarket.Models.VietnameseAdministrativeUnits;
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

        modelBuilder.Entity<Ward>()
            .ToTable("wards")
            .HasKey(p => p.Code);

        modelBuilder.Entity<Ward>()
            .Property(p => p.Code)
            .HasColumnName("code")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<Ward>()
            .Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<Ward>()
            .Property(p => p.NameEn)
            .HasColumnName("name_en")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<Ward>()
            .Property(p => p.FullName)
            .HasColumnName("full_name")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<Ward>()
            .Property(p => p.FullNameEn)
            .HasColumnName("full_name_en")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<Ward>()
            .Property(p => p.CodeName)
            .HasColumnName("code_name")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<Ward>()
            .Property(p => p.DistrictCode)
            .HasColumnName("district_code")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<Ward>()
            .Property(p => p.AdministrativeUnitId)
            .HasColumnName("administrative_unit_id")
            .HasColumnType("integer");

        modelBuilder.Entity<Ward>()
            .HasOne<AdministrativeUnit>(x => x.AdministrativeUnit)
            .WithMany(a => a.Wards)
            .HasForeignKey(w => w.AdministrativeUnitId);
        
        modelBuilder.Entity<Ward>()
            .HasOne<District>(w => w.District)
            .WithMany(d => d.Wards)
            .HasForeignKey(w => w.DistrictCode);
        
        modelBuilder.Entity<District>()
            .ToTable("districts")
            .HasKey(p => p.Code);

        modelBuilder.Entity<District>()
            .Property(p => p.Code)
            .HasColumnName("code")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<District>()
            .Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<District>()
            .Property(p => p.NameEn)
            .HasColumnName("name_en")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<District>()
            .Property(p => p.FullName)
            .HasColumnName("full_name")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<District>()
            .Property(p => p.FullNameEn)
            .HasColumnName("full_name_en")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<District>()
            .Property(p => p.CodeName)
            .HasColumnName("code_name")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<District>()
            .Property(p => p.ProvinceCode)
            .HasColumnName("province_code")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<District>()
            .Property(p => p.AdministrativeUnitId)
            .HasColumnName("administrative_unit_id")
            .HasColumnType("integer");

        modelBuilder.Entity<District>()
            .HasOne<AdministrativeUnit>(x => x.AdministrativeUnit)
            .WithMany(a => a.Districts)
            .HasForeignKey(d => d.AdministrativeUnitId);
        
        modelBuilder.Entity<District>()
            .HasOne<Province>(x => x.Province)
            .WithMany(p => p.Districts)
            .HasForeignKey(d => d.ProvinceCode);
        
        modelBuilder.Entity<Province>()
            .ToTable("provinces")
            .HasKey(p => p.Code);

        modelBuilder.Entity<Province>()
            .Property(p => p.Code)
            .HasColumnName("code")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<Province>()
            .Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<Province>()
            .Property(p => p.NameEn)
            .HasColumnName("name_en")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<Province>()
            .Property(p => p.FullName)
            .HasColumnName("full_name")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<Province>()
            .Property(p => p.FullNameEn)
            .HasColumnName("full_name_en")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<Province>()
            .Property(p => p.CodeName)
            .HasColumnName("code_name")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<Province>()
            .Property(p => p.AdministrativeUnitId)
            .HasColumnName("administrative_unit_id")
            .HasColumnType("integer");

        modelBuilder.Entity<Province>()
            .HasOne<AdministrativeUnit>(x => x.AdministrativeUnit)
            .WithMany(a => a.Provinces)
            .HasForeignKey(p => p.AdministrativeUnitId);
        
        modelBuilder.Entity<Province>()
            .Property(p => p.AdministrativeRegionId)
            .HasColumnName("administrative_region_id")
            .HasColumnType("integer");
        
        modelBuilder.Entity<Province>()
            .HasOne<AdministrativeRegion>(x => x.AdministrativeRegion)
            .WithMany(p => p.Provinces)
            .HasForeignKey(p => p.AdministrativeRegionId);

        modelBuilder.Entity<AdministrativeUnit>()
            .ToTable("administrative_units")
            .HasKey(p => p.Id);
        
        modelBuilder.Entity<AdministrativeUnit>()
            .Property(p => p.Id)
            .HasColumnName("id");

        modelBuilder.Entity<AdministrativeUnit>()
            .Property(p => p.FullName)
            .HasColumnName("full_name")
            .HasColumnType("varchar");

        modelBuilder.Entity<AdministrativeUnit>()
            .Property(p => p.FullNameEn)
            .HasColumnName("full_name_en")
            .HasColumnType("varchar");

        modelBuilder.Entity<AdministrativeUnit>()
            .Property(p => p.ShortName)
            .HasColumnName("short_name")
            .HasColumnType("varchar");

        modelBuilder.Entity<AdministrativeUnit>()
            .Property(p => p.ShortNameEn)
            .HasColumnName("short_name_en")
            .HasColumnType("varchar");

        modelBuilder.Entity<AdministrativeUnit>()
            .Property(p => p.CodeName)
            .HasColumnName("code_name")
            .HasColumnType("varchar");

        modelBuilder.Entity<AdministrativeUnit>()
            .Property(p => p.CodeNameEn)
            .HasColumnName("code_name_en")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<AdministrativeRegion>()
            .ToTable("administrative_regions")
            .HasKey(p => p.Id);
        
        modelBuilder.Entity<AdministrativeRegion>()
            .Property(p => p.Id)
            .HasColumnName("id");

        modelBuilder.Entity<AdministrativeRegion>()
            .Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar");

        modelBuilder.Entity<AdministrativeRegion>()
            .Property(p => p.NameEn)
            .HasColumnName("name_en")
            .HasColumnType("varchar");
        
        modelBuilder.Entity<AdministrativeRegion>()
            .Property(p => p.CodeName)
            .HasColumnName("code_name")
            .HasColumnType("varchar");

        modelBuilder.Entity<AdministrativeRegion>()
            .Property(p => p.CodeNameEn)
            .HasColumnName("code_name_en")
            .HasColumnType("varchar");

        base.OnModelCreating(modelBuilder);
    }
}