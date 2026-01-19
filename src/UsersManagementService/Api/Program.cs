using InnoShop.UsersManagementService.Api.ConfigurationHelpers;
using InnoShop.UsersManagementService.Api.ExceptionHandlers;
using InnoShop.UsersManagementService.Application;
using InnoShop.UsersManagementService.Application.Mappings;
using InnoShop.UsersManagementService.Domain.Interfaces;
using InnoShop.UsersManagementService.Infrastructure.DeletionManagers;
using InnoShop.UsersManagementService.Infrastructure.Persistence;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Scalar.AspNetCore;

namespace InnoShop.UsersManagementService.Api;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddAutoMapper(typeof(UserProfile));

        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(AssemblyMarker).Assembly));

        builder.Services.AddHttpClient<IProductsDeletionManager, ProductDeletionManager>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5030");
        });

        builder.Services.RegisterDi();

        builder.Services.AddCustomAuthentication(builder);

        builder.Services.RegisterDbContext(builder);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.Services.AddExceptionHandler<GeneralExceptionHandler>();
        builder.Services.AddProblemDetails();

        builder.Configuration.AddEnvironmentVariables();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            db.Database.Migrate();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();

            app.MapScalarApiReference();
        }

        app.UseExceptionHandler();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}