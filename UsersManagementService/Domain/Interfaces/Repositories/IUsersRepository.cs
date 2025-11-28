using InnoShop.UsersManagementService.Domain.Entities;

namespace InnoShop.UsersManagementService.Domain.Interfaces.Repositories;

public interface IUsersRepository : IRepository<User>
{
    Task<User?> GetByUsernameAsync(string username);
}
