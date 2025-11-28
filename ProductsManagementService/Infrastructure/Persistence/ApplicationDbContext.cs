using InnoShop.ProductsManagementService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnoShop.ProductsManagementService.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        PopulateWithInitialSeedUsersTable(modelBuilder);

        modelBuilder.Entity<Product>()
            .Property(e => e.Price)
            .HasPrecision(10, 2);

        base.OnModelCreating(modelBuilder);
    }

    private static void PopulateWithInitialSeedUsersTable(ModelBuilder modelBuilder)
    {
        var now = DateOnly.FromDateTime(DateTime.Now);
        modelBuilder.Entity<Product>().HasData(
                    new Product { Id = 1, Name = "Prod1", Description = "Desc1", Price = 10, Available = true, Deleted = false, OwnerId = 1, CreationDate = now },
                    new Product { Id = 2, Name = "Prod2", Description = "Desc2", Price = 20, Available = true, Deleted = false, OwnerId = 2, CreationDate = now }
                );
    }
}
