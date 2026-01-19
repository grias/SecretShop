using InnoShop.UsersManagementService.Domain.Entities;

namespace InnoShop.UsersManagementService.Domain.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
