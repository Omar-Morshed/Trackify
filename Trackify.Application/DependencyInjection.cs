using System;
using Microsoft.Extensions.DependencyInjection;

namespace Trackify.Application;

public static class DependencyInjection
{
    public static void AddApplicationConfigurations(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });
    }
}
