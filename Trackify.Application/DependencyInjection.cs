using System;
using System.Reflection;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Trackify.Application.Behaviors;

namespace Trackify.Application;

public static class DependencyInjection
{
    public static void AddApplicationConfigurations(this IServiceCollection services)
    {
        //* CQRS & MediatR Config
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            //* Registers the MediatR Pipelines
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        //* Fluent Validation Configurations
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        //* Mapster Config
        // 🔍 مسح وتسجيل كل ملفات الـ Mapping التي ترث من IRegister
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);

    }
}
