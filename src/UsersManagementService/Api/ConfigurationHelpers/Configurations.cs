using InnoShop.UsersManagementService.Domain.Interfaces;
using InnoShop.UsersManagementService.Domain.Interfaces.Repositories;
using InnoShop.UsersManagementService.Infrastructure.JwtTokenGenerators;
using InnoShop.UsersManagementService.Infrastructure.DeletionManagers;
using InnoShop.UsersManagementService.Infrastructure.PasswordHashers;
using InnoShop.UsersManagementService.Infrastructure.Persistence;
using InnoShop.UsersManagementService.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InnoShop.UsersManagementService.Api.ConfigurationHelpers;

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
            options.UseSqlServer(builder.Configuration.GetConnectionString("InnoShopUserAuthServiceDb"));
        });
    }

    public static void RegisterDi(this IServiceCollection services)
    {
        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<IPasswordHasher, CustomPasswordHasher>();
        services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddTransient<IRecoveryTokenGenerator, IRecoveryTokenGenerator>();
    }
}
