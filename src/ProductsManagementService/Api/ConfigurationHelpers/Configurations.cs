using InnoShop.ProductsManagementService.Api.Filters;
using InnoShop.ProductsManagementService.Domain.Interfaces.Repositories;
using InnoShop.ProductsManagementService.Infrastructure.Persistence;
using InnoShop.ProductsManagementService.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InnoShop.ProductsManagementService.Api.ConfigurationHelpers;

public static class Configurations
{
    public static AuthenticationBuilder AddCustomAuthentication(this IServiceCollection services, WebApplicationBuilder builder)
    {
        return services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["InnoShopAuth:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["InnoShopAuth:Audience"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["InnoShopAuth:Token"]!)),
                    ValidateIssuerSigningKey = true
                };
            });
    }

    public static IServiceCollection RegisterDbContext(this IServiceCollection services, WebApplicationBuilder builder)
    {
        return services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("InnoShopProductsManagementServiceDb"));
        });
    }

    public static void RegisterDi(this IServiceCollection services)
    {
        services.AddTransient<IProductsRepository, ProductsRepository>();
        services.AddScoped<AuthorizeOwnerFilter>();
    }
}
