using InnoShop.ProductsManagementService.Domain.Entities;
using InnoShop.ProductsManagementService.Domain.Interfaces.Repositories;
using InnoShop.ProductsManagementService.Domain.Queries;
using InnoShop.ProductsManagementService.Infrastructure.Persistence;
using InnoShop.ProductsManagementService.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace InnoShop.ProductsManagementService.Infrastructure.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly ApplicationDbContext _context;

    public ProductsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(Product entity)
    {
        await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Product?> DeleteAsync(int id)
    {
        var ProductToDelete = await GetByIdAsync(id);
        if (ProductToDelete is null)
        {
            return null;
        }

        ProductToDelete.Deleted = true;
        await _context.SaveChangesAsync();

        return ProductToDelete;
    }

    public async Task<List<Product>> GetAllAsync(QueryObject queryObject)
    {
        var books =  _context.Products.AsQueryable();

        return await books
            .FilterByName(queryObject)
            .FilterByOwnerId(queryObject)
            .Paginate(queryObject).ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product is null)
        {
            return null;
        }

        return product;
    }

    public async Task<Product?> UpdateAsync(Product entity)
    {
        var productToUpdate = await GetByIdAsync(entity.Id);
        if (productToUpdate is null)
        {
            return null;
        }

        productToUpdate.Name = entity.Name;
        productToUpdate.Description = entity.Description;
        productToUpdate.Price = entity.Price;
        productToUpdate.Available = entity.Available;
        await _context.SaveChangesAsync();

        return productToUpdate;
    }
}
