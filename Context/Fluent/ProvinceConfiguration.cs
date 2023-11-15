using GoodMarket.Models.VietnameseAdministrativeUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Context.Fluent;

public class ProvinceConfiguration: IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> modelBuilder)
    {
        modelBuilder
            .ToTable("provinces")
            .HasKey(p => p.Code);

        modelBuilder
            .Property(p => p.Code)
            .HasColumnName("code")
            .HasColumnType("varchar");
        
        modelBuilder
            .Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar");
        
        modelBuilder
            .Property(p => p.NameEn)
            .HasColumnName("name_en")
            .HasColumnType("varchar");
        
        modelBuilder
            .Property(p => p.FullName)
            .HasColumnName("full_name")
            .HasColumnType("varchar");
        
        modelBuilder
            .Property(p => p.FullNameEn)
            .HasColumnName("full_name_en")
            .HasColumnType("varchar");
        
        modelBuilder
            .Property(p => p.CodeName)
            .HasColumnName("code_name")
            .HasColumnType("varchar");
        
        modelBuilder
            .Property(p => p.AdministrativeUnitId)
            .HasColumnName("administrative_unit_id")
            .HasColumnType("integer");

        modelBuilder
            .HasOne<AdministrativeUnit>(x => x.AdministrativeUnit)
            .WithMany(a => a.Provinces)
            .HasForeignKey(p => p.AdministrativeUnitId);
        
        modelBuilder
            .Property(p => p.AdministrativeRegionId)
            .HasColumnName("administrative_region_id")
            .HasColumnType("integer");
        
        modelBuilder
            .HasOne<AdministrativeRegion>(x => x.AdministrativeRegion)
            .WithMany(p => p.Provinces)
            .HasForeignKey(p => p.AdministrativeRegionId);

    }
}