using InnoShop.UsersManagementService.Domain.Enumerators;

namespace InnoShop.UsersManagementService.Application.Dtos.Responses;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserRoles Role { get; set; } = UserRoles.User;
    public bool Deleted { get; set; } = false;
}
