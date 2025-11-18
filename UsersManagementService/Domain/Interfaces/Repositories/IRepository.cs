namespace InnoShop.UsersManagementService.Domain.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(int id);

    Task<TEntity> CreateAsync(TEntity entity);

    Task<TEntity?> UpdateAsync(TEntity entity);

    Task<TEntity?> DeleteAsync(int id);
}
