using InnoShop.UsersManagementService.Domain.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace InnoShop.UsersManagementService.Application.Dtos.Requests;

public class CreateUserDto
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public UserRoles Role { get; set; } = UserRoles.User;
}
