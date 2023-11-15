using GoodMarket.Models.VietnameseAdministrativeUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Context.Fluent;

public class AdministrativeRegionConfiguration: IEntityTypeConfiguration<AdministrativeRegion>
{
    public void Configure(EntityTypeBuilder<AdministrativeRegion> modelBuilder)
    {
        modelBuilder
            .ToTable("administrative_regions")
            .HasKey(p => p.Id);
        
        modelBuilder
            .Property(p => p.Id)
            .HasColumnName("id");

        modelBuilder
            .Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar");

        modelBuilder
            .Property(p => p.NameEn)
            .HasColumnName("name_en")
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