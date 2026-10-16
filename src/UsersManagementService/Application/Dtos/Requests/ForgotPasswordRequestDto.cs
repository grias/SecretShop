using System.ComponentModel.DataAnnotations;

namespace InnoShop.UsersManagementService.Application.Dtos.Requests;

public class ForgotPasswordRequestDto
{
    [Required]
    public string Email { get; set; } = string.Empty;
}
