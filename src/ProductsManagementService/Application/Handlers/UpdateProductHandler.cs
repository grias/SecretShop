using AutoMapper;
using InnoShop.ProductsManagementService.Application.Commands;
using InnoShop.ProductsManagementService.Application.Dtos;
using InnoShop.ProductsManagementService.Domain.Exceptions;
using InnoShop.ProductsManagementService.Domain.Interfaces.Repositories;
using MediatR;

namespace InnoShop.ProductsManagementService.Application.Handlers;

public class UpdateProductHandler(IProductsRepository _productsRepository, IMapper _mapper) : IRequestHandler<UpdateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var existingProduct = await _productsRepository.GetByIdAsync(request.Id);

        if (existingProduct is null)
        {
            throw new ProductNotFoundException(request.Id);
        }

        var productToUpdate = _mapper.Map(request.ProductDto, existingProduct);
        var updatedProduct = await _productsRepository.UpdateAsync(productToUpdate);
        return _mapper.Map<ProductDto>(updatedProduct);
    }
}
