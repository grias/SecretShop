using InnoShop.ProductsManagementService.Api.ExceptionHandlers;
using InnoShop.ProductsManagementService.Application;
using InnoShop.ProductsManagementService.Application.Behaviors;
using InnoShop.ProductsManagementService.Application.Mappings;
using InnoShop.ProductsManagementService.Domain.Interfaces.Repositories;
using InnoShop.ProductsManagementService.Infrastructure.Persistence;
using InnoShop.ProductsManagementService.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InnoShop.ProductsManagementService.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddAutoMapper(typeof(ProductProfile));

        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(AssemblyMarker).Assembly));

        builder.Services.AddTransient<IProductsRepository, ProductsRepository>();

        RegisterDbContext(builder);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.Services.AddExceptionHandler<GeneralExceptionHandler>();
        builder.Services.AddProblemDetails();

        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        builder.Services.AddValidatorsFromAssemblyContaining<AssemblyMarker>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "v1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }

    private static void RegisterDbContext(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("InnoShopProductsManagementServiceDb"));
        });
    }
}
