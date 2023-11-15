using GoodMarket.Context.Fluent;
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
        modelBuilder.ApplyConfiguration(new WardConfiguration());
        modelBuilder.ApplyConfiguration(new DistrictConfiguration());
        modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
        modelBuilder.ApplyConfiguration(new AdministrativeUnitConfiguration());
        modelBuilder.ApplyConfiguration(new AdministrativeRegionConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new FormFieldConfiguration());
        modelBuilder.ApplyConfiguration(new FormConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}