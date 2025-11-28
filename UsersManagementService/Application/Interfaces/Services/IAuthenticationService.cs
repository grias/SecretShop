using System;
using System.Collections.Generic;
using System.Text;

namespace InnoShop.UsersManagementService.Application.Interfaces.Services;

public interface IAuthenticationService
{
    Task<string> LoginAsync(string username, string password);
}
