using InnoShop.UsersManagementService.Domain.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace InnoShop.UsersManagementService.Application.Dtos.Requests;

public class UpdateUserDto
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserRoles? Role { get; set; } = UserRoles.User;
}
