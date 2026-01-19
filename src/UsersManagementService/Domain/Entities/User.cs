using InnoShop.UsersManagementService.Domain.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace InnoShop.UsersManagementService.Domain.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string PasswordHash { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public bool Deleted { get; set; }
    [Required]
    public UserRoles Role { get; set; } = UserRoles.User;
}
