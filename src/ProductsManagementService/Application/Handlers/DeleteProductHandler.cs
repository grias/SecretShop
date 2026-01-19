using InnoShop.ProductsManagementService.Application.Commands;
using InnoShop.ProductsManagementService.Domain.Exceptions;
using InnoShop.ProductsManagementService.Domain.Interfaces.Repositories;
using MediatR;

namespace InnoShop.ProductsManagementService.Application.Handlers;

public class DeleteProductHandler(IProductsRepository _productsRepository) : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productsRepository.GetByIdAsync(request.Id);

        if (product is null)
        {
            throw new ProductNotFoundException(request.Id);
        }

        var deletedProduct = await _productsRepository.DeleteAsync(request.Id);
    }
}
