
using InnoShop.UsersManagementService.Domain.Entities;
using InnoShop.UsersManagementService.Domain.Enumerators;
using Microsoft.EntityFrameworkCore;

namespace InnoShop.UsersManagementService.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        PopulateWithInitialSeedUsersTable(modelBuilder);

        modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

        base.OnModelCreating(modelBuilder);
    }

    private static void PopulateWithInitialSeedUsersTable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, Username = "admin", PasswordHash = "123", Deleted = false, Email = "adm@mail.com", Role = UserRoles.Admin},
                    new User { Id = 2, Username = "bob", PasswordHash = "123", Deleted = false, Email = "bob@mail.com", Role = UserRoles.User}
                );
    }
}
