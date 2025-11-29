using System.ComponentModel.DataAnnotations;

namespace InnoShop.UsersManagementService.Application.Dtos.Requests;

public class RegisterRequestDto
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
}
