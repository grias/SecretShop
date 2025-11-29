using InnoShop.UsersManagementService.Domain.Entities;
using InnoShop.UsersManagementService.Domain.Queries;

namespace InnoShop.UsersManagementService.Infrastructure.Helpers;

public static class QueryHelper
{
    public static IQueryable<TEntity> Paginate<TEntity>(this IQueryable<TEntity> entities, UserQueryObject queryObject)
    {
        var pagesToSkip = (queryObject.PageNumber - 1) * queryObject.PageSize;
        entities = entities.Skip(pagesToSkip).Take(queryObject.PageSize);
        return entities;
    }
}
