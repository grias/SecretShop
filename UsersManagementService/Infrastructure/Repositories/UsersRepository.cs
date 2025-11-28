
using InnoShop.UsersManagementService.Domain.Entities;
using InnoShop.UsersManagementService.Domain.Interfaces.Repositories;
using InnoShop.UsersManagementService.Domain.Queries;
using InnoShop.UsersManagementService.Infrastructure.Persistence;
using InnoShop.UsersManagementService.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace InnoShop.UsersManagementService.Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ApplicationDbContext _context;

    public UsersRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> CreateAsync(User entity)
    {
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<User?> DeleteAsync(int id)
    {
        var UserToDelete = await GetByIdAsync(id);
        if (UserToDelete is null)
        {
            return null;
        }

        UserToDelete.Deleted = true;
        await _context.SaveChangesAsync();

        return UserToDelete;
    }

    public async Task<List<User>> GetAllAsync(UserQueryObject queryObject)
    {
        var users = _context.Users.AsQueryable();

        return await users
            .FilterNotDeleted()
            .Paginate(queryObject).ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user is null || user.Deleted)
        {
            return null;
        }

        return user;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

        if (user is null || user.Deleted)
        {
            return null;
        }

        return user;
    }

    public async Task<User?> UpdateAsync(User entity)
    {
        var userToUpdate = await GetByIdAsync(entity.Id);

        if (userToUpdate is null)
        {
            return null;
        }

        userToUpdate.Username = entity.Username;
        userToUpdate.Email = entity.Email;
        userToUpdate.Role = entity.Role;

        await _context.SaveChangesAsync();

        return userToUpdate;
    }
}
