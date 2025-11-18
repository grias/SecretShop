using System.ComponentModel.DataAnnotations;

namespace InnoShop.UsersManagementService.Domain.Entities;

public class RefreshToken
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Token { get; set; } = string.Empty;
    [Required]
    public DateTime ExpirationDate { get; set; }
    [Required]
    public bool IsRevoked { get; set; }
    [Required]
    public int UserId { get; set; }
}
