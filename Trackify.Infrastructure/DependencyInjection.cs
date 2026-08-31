using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trackify.Application.Interface;
using Trackify.Infrastructure.Repository.Implementation;

namespace Trackify.Infrastructure;

//* Used for Registering the services in the Dependency Injection Container, Instead of writing them all in the Program.cs
public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(DbOptionsBuilder =>
        {
            DbOptionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        });
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
