using InnoShop.ProductsManagementService.Application.Dtos;
using MediatR;

namespace InnoShop.ProductsManagementService.Application.Queries;

public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;
