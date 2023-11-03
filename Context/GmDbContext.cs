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
    }
}