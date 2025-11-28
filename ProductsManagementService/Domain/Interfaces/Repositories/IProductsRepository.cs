using InnoShop.ProductsManagementService.Domain.Entities;
using InnoShop.ProductsManagementService.Domain.Queries;

namespace InnoShop.ProductsManagementService.Domain.Interfaces.Repositories;

public interface IProductsRepository : IRepository<Product>
{
    public Task<List<Product>> GetByOwnerId(int id, QueryObject queryObject);
}
