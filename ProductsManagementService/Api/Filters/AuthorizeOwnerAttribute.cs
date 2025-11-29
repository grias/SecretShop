using InnoShop.ProductsManagementService.Domain.Interfaces.Repositories;
using InnoShop.ProductsManagementService.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace InnoShop.ProductsManagementService.Api.Filters;

public class AuthorizeOwnerFilter(IProductsRepository _repository) : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ActionArguments.TryGetValue("id", out var idObj) && idObj is int id)
        {
            var product = await _repository.GetByIdAsync(id);
            var userId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (product is null || userId is null || product.OwnerId.ToString() != userId)
            {
                context.Result = new ForbidResult();
                return;
            }
        }

        await next();
    }
}
