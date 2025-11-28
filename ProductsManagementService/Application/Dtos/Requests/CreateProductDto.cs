using System.ComponentModel.DataAnnotations;


namespace InnoShop.ProductsManagementService.Application.Dtos.Requests;

public class CreateProductDto()
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public decimal Price { get; set; } = decimal.Zero;
    [Required]
    public bool Available { get; set; } = true;
}
