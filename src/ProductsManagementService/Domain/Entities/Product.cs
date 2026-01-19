using System.ComponentModel.DataAnnotations;

namespace InnoShop.ProductsManagementService.Domain.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public decimal Price { get; set; } = decimal.Zero;
    [Required]
    public bool Available { get; set; } = true;
    [Required]
    public int OwnerId { get; set; } = 0;
    [Required]
    public DateOnly CreationDate { get; set; } = new DateOnly();
    [Required]
    public bool Deleted { get; set; } = false;
}
