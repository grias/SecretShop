using InnoShop.UsersManagementService.Domain.Entities;
using System.Security.Claims;

namespace InnoShop.UsersManagementService.Domain.Interfaces;

public interface IRecoveryTokenValidator
{
    public int? ReadUserIdWithoutValidation(string token);
    public ClaimsPrincipal? ValidateToken(string token, User user);
}
