using InnoShop.ProductsManagementService.Application.Commands;
using InnoShop.ProductsManagementService.Domain.Interfaces.Repositories;
using MediatR;

namespace InnoShop.ProductsManagementService.Application.Handlers;

public class RecoverProductsByOwnerIdHandler(IProductsRepository _productsRepository) : IRequestHandler<RecoverProductsByOwnerIdCommand>
{
    public async Task Handle(RecoverProductsByOwnerIdCommand request, CancellationToken cancellationToken)
    {
        await _productsRepository.RecoverByOwnerIdAsync(request.OwnerId);
    }
}
