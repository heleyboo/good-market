using GoodMarket.Models.VietnameseAdministrativeUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Context.Fluent;

public class WardConfiguration: IEntityTypeConfiguration<Ward>
{
    public void Configure(EntityTypeBuilder<Ward> modelBuilder)
    {
        modelBuilder
            .ToTable("wards")
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
            .Property(p => p.DistrictCode)
            .HasColumnName("district_code")
            .HasColumnType("varchar");
        
        modelBuilder
            .Property(p => p.AdministrativeUnitId)
            .HasColumnName("administrative_unit_id")
            .HasColumnType("integer");

        modelBuilder
            .HasOne<AdministrativeUnit>(x => x.AdministrativeUnit)
            .WithMany(a => a.Wards)
            .HasForeignKey(w => w.AdministrativeUnitId);
        
        modelBuilder
            .HasOne<District>(w => w.District)
            .WithMany(d => d.Wards)
            .HasForeignKey(w => w.DistrictCode);
    }
}