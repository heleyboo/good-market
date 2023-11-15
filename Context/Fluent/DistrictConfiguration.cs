using GoodMarket.Models.VietnameseAdministrativeUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Context.Fluent;

public class DistrictConfiguration: IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> modelBuilder)
    {
        modelBuilder
            .ToTable("districts")
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
            .Property(p => p.ProvinceCode)
            .HasColumnName("province_code")
            .HasColumnType("varchar");
        
        modelBuilder
            .Property(p => p.AdministrativeUnitId)
            .HasColumnName("administrative_unit_id")
            .HasColumnType("integer");

        modelBuilder
            .HasOne<AdministrativeUnit>(x => x.AdministrativeUnit)
            .WithMany(a => a.Districts)
            .HasForeignKey(d => d.AdministrativeUnitId);
        
        modelBuilder
            .HasOne<Province>(x => x.Province)
            .WithMany(p => p.Districts)
            .HasForeignKey(d => d.ProvinceCode);
    }
}