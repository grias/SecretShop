using InnoShop.UsersManagementService.Api.ExceptionHandlers;
using InnoShop.UsersManagementService.Application;
using InnoShop.UsersManagementService.Application.Mappings;
using InnoShop.UsersManagementService.Domain.Interfaces.Repositories;
using InnoShop.UsersManagementService.Infrastructure.Persistence;
using InnoShop.UsersManagementService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

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

        builder.Services.AddTransient<IUsersRepository, UsersRepository>();

        RegisterDbContext(builder);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.Services.AddExceptionHandler<GeneralExceptionHandler>();
        builder.Services.AddProblemDetails();

        builder.Configuration.AddEnvironmentVariables();

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
            options.UseSqlServer(builder.Configuration.GetConnectionString("InnoShopUserAuthServiceDb"));
        });
    }
}

