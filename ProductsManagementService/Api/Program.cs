using FluentValidation;
using InnoShop.ProductsManagementService.Api.ConfigurationHelpers;
using InnoShop.ProductsManagementService.Api.ExceptionHandlers;
using InnoShop.ProductsManagementService.Application;
using InnoShop.ProductsManagementService.Application.Behaviors;
using InnoShop.ProductsManagementService.Application.Mappings;
using MediatR;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Scalar.AspNetCore;

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

        builder.Services.RegisterDi();

        builder.Services.AddCustomAuthentication(builder);

        builder.Services.RegisterDbContext(builder);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.Services.AddExceptionHandler<GeneralExceptionHandler>();
        builder.Services.AddProblemDetails();

        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        builder.Services.AddValidatorsFromAssemblyContaining<AssemblyMarker>();

        builder.Configuration.AddEnvironmentVariables();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();

            app.MapScalarApiReference();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
