using InnoShop.UsersManagementService.Domain.Entities;

namespace InnoShop.UsersManagementService.Domain.Interfaces;

public interface IRecoveryTokenGenerator
{
    string GenerateToken(User user);
}
