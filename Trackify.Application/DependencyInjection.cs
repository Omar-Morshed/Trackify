using System;
using System.Reflection;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Trackify.Application;

public static class DependencyInjection
{
    public static void AddApplicationConfigurations(this IServiceCollection services)
    {
        //* CQRS & MediatR Config
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        //* Mapster Config
        // 🔍 مسح وتسجيل كل ملفات الـ Mapping التي ترث من IRegister
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
    }
}
