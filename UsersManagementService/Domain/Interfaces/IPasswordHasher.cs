using InnoShop.UsersManagementService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnoShop.UsersManagementService.Domain.Interfaces;

public interface IPasswordHasher
{
    string HashPassword(User user, string password);

    bool VerifyPassword(User user, string password);
}
