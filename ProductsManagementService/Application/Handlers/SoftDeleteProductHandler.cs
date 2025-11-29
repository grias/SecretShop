using InnoShop.ProductsManagementService.Application.Commands;
using InnoShop.ProductsManagementService.Domain.Exceptions;
using InnoShop.ProductsManagementService.Domain.Interfaces.Repositories;
using MediatR;

namespace InnoShop.ProductsManagementService.Application.Handlers;

public class SoftDeleteProductHandler(IProductsRepository _productsRepository) : IRequestHandler<SoftDeleteProductCommand>
{
    public async Task Handle(SoftDeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _productsRepository.SoftDeleteByOwnerIdAsync(request.OwnerId);
    }
}
