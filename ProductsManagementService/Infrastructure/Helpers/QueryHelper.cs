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

    public static IQueryable<Product> FilterByName(this IQueryable<Product> products, QueryObject queryObject)
    {

        if (!string.IsNullOrWhiteSpace(queryObject.ProductName))
        {
            products = products.Where(product => product.Name.Contains(queryObject.ProductName));
        }

        return products;
    }

    public static IQueryable<Product> FilterByOwnerId(this IQueryable<Product> products, QueryObject queryObject)
    {
        if (queryObject.OwnerId.HasValue)
        {
            products = products.Where(product => product.OwnerId == queryObject.OwnerId);
        }

        return products;
    }

    public static IQueryable<Product> FilterNotDeleted(this IQueryable<Product> products)
    {
        return products.Where(product => product.Deleted == false);
    }
}
