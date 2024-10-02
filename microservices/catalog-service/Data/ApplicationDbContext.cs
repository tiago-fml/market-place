using catalog_service.Models;
using Microsoft.EntityFrameworkCore;

namespace catalog_service.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductPrice> ProductsPrices { get; set; }
    public DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}