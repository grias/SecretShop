using System.ComponentModel.DataAnnotations;

namespace InnoShop.UsersManagementService.Api.Dtos.Requests;

public class LoginRequestDto
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
