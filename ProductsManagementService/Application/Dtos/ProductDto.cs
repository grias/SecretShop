using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InnoShop.ProductsManagementService.Application.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;
    public bool Available { get; set; } = false;
    public int OwnerId { get; set; } = 0;
    public DateOnly CreationDate { get; set; } = new DateOnly();
}
