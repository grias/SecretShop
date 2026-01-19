using InnoShop.ProductsManagementService.Domain.Entities;

namespace InnoShop.ProductsManagementService.Domain.Interfaces.Repositories;

public interface IProductsRepository : IRepository<Product>
{
    Task SoftDeleteByOwnerIdAsync(int ownerId);
    Task RecoverByOwnerIdAsync(int ownerId);
}
