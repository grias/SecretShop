using InnoShop.ProductsManagementService.Application.Queries;
using InnoShop.ProductsManagementService.Application.Dtos;
using MediatR;
using InnoShop.ProductsManagementService.Domain.Interfaces.Repositories;
using AutoMapper;

namespace InnoShop.ProductsManagementService.Application.Handlers;

public class GetAllProductsHandler(IProductsRepository _productsRepository, IMapper _mapper) : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productsRepository.GetAllAsync(request.QueryObject);
        return _mapper.Map<List<ProductDto>>(products);
    }
}
