using System.ComponentModel.DataAnnotations;

namespace InnoShop.UsersManagementService.Api.Dtos.Requests;

public class CreateUserRequest
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
}
