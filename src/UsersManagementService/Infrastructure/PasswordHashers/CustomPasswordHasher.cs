using InnoShop.UsersManagementService.Domain.Entities;
using InnoShop.UsersManagementService.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace InnoShop.UsersManagementService.Infrastructure.PasswordHashers;

public class CustomPasswordHasher : IPasswordHasher
{
    public string HashPassword(User user, string password)
    {
        return new PasswordHasher<User>().HashPassword(user, password);
    }

    public bool VerifyPassword(User user, string password)
    {
        var verificationResult = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, password);
        return verificationResult == PasswordVerificationResult.Success;
    }
}
