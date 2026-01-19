using InnoShop.ProductsManagementService.Application.Dtos;
using InnoShop.ProductsManagementService.Domain.Queries;
using MediatR;

namespace InnoShop.ProductsManagementService.Application.Queries;

public record GetAllProductsQuery(QueryObject QueryObject) : IRequest<List<ProductDto>>;
