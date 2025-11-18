
using InnoShop.UsersManagementService.Domain.Entities;
using InnoShop.UsersManagementService.Domain.Interfaces.Repositories;

namespace InnoShop.UsersManagementService.Infrastructure.Repositories;

public class UserRepository : IUsersRepository
{
    public Task<User> CreateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User?> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}
