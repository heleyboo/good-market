using GoodMarket.Models.VietnameseAdministrativeUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Context.Fluent;

public class AdministrativeUnitConfiguration: IEntityTypeConfiguration<AdministrativeUnit>
{
    public void Configure(EntityTypeBuilder<AdministrativeUnit> modelBuilder)
    {
        modelBuilder
            .ToTable("administrative_units")
            .HasKey(p => p.Id);
        
        modelBuilder
            .Property(p => p.Id)
            .HasColumnName("id");

        modelBuilder
            .Property(p => p.FullName)
            .HasColumnName("full_name")
            .HasColumnType("varchar");

        modelBuilder
            .Property(p => p.FullNameEn)
            .HasColumnName("full_name_en")
            .HasColumnType("varchar");

        modelBuilder
            .Property(p => p.ShortName)
            .HasColumnName("short_name")
            .HasColumnType("varchar");

        modelBuilder
            .Property(p => p.ShortNameEn)
            .HasColumnName("short_name_en")
            .HasColumnType("varchar");

        modelBuilder
            .Property(p => p.CodeName)
            .HasColumnName("code_name")
            .HasColumnType("varchar");

        modelBuilder
            .Property(p => p.CodeNameEn)
            .HasColumnName("code_name_en")
            .HasColumnType("varchar");
    }
}