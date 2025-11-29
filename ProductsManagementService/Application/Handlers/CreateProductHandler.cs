using AutoMapper;
using InnoShop.ProductsManagementService.Application.Commands;
using InnoShop.ProductsManagementService.Application.Dtos;
using InnoShop.ProductsManagementService.Domain.Entities;
using InnoShop.ProductsManagementService.Domain.Interfaces.Repositories;
using MediatR;

namespace InnoShop.ProductsManagementService.Application.Handlers;

public class CreateProductHandler(IProductsRepository _productsRepository, IMapper _mapper) : IRequestHandler<CreateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productToCreate = _mapper.Map<Product>(request.ProductDto);
        productToCreate.OwnerId = request.UserId;
        var product = await _productsRepository.CreateAsync(productToCreate);
        return _mapper.Map<ProductDto>(product);
    }
}
