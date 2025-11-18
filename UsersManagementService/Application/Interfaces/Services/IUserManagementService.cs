using System;
using System.Collections.Generic;
using System.Text;
using InnoShop.UsersManagementService.Application.Dtos;

namespace InnoShop.UsersManagementService.Application.Interfaces.Services;

public interface IUserManagementService
{
    Task<List<UserDto>> GetAllAsync();

    Task<UserDto> GetByIdAsync(int id);

    Task<UserDto> CreateAsync();

    Task<UserDto> UpdateAsync(int id);

    Task DeleteAsync(int id);
}
