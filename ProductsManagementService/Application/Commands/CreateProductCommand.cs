using InnoShop.ProductsManagementService.Application.Dtos;
using InnoShop.ProductsManagementService.Application.Dtos.Requests;
using MediatR;


namespace InnoShop.ProductsManagementService.Application.Commands;

public record CreateProductCommand(CreateProductDto ProductDto) : IRequest<ProductDto>;