using InnoShop.ProductsManagementService.Domain.Entities;
using InnoShop.ProductsManagementService.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnoShop.ProductsManagementService.Infrastructure.Helpers;

public static class QueryHelper
{
    public static IQueryable<TEntity> Paginate<TEntity>(this IQueryable<TEntity> entities, QueryObject queryObject)
    {
        var pagesToSkip = (queryObject.PageNumber - 1) * queryObject.PageSize;
        entities = entities.Skip(pagesToSkip).Take(queryObject.PageSize);
        return entities;
    }

    public static IQueryable<Product> FilterByName(this IQueryable<Product> authors, QueryObject queryObject)
    {

        if (!string.IsNullOrWhiteSpace(queryObject.ProductName))
        {
            authors = authors.Where(author => author.Name.Contains(queryObject.ProductName));
        }

        return authors;
    }
}
