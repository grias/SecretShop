using AutoMapper;
using InnoShop.ProductsManagementService.Application.Dtos;
using InnoShop.ProductsManagementService.Application.Queries;
using InnoShop.ProductsManagementService.Domain.Interfaces.Repositories;
using InnoShop.ProductsManagementService.Domain.Exceptions;
using MediatR;

namespace InnoShop.ProductsManagementService.Application.Handlers;

public class GetProductByIdHandler(IProductsRepository _productsRepository, IMapper _mapper) : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productsRepository.GetByIdAsync(request.Id);

        if (product is null)
        {
            throw new ProductNotFoundException(request.Id);
        }

        return _mapper.Map<ProductDto>(product);
    }
}
