using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using z.Fellowship.Application.Rules;
using z.Fellowship.Application.Pipelines.Validation;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using z.Fellowship.Application.Logging;
using z.Fellowship.CrossCuttingConcerns.Serilog.Logger;
using z.Fellowship.CrossCuttingConcerns.Serilog;

namespace Application;

public static class ApplicationServiceRegistraion
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());


        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));


            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));


        });

        services.AddSingleton<LoggerServiceBase, RabbitMQLogger>();
        return services; 
    }

    public static IServiceCollection AddSubClassesOfType(
         this IServiceCollection services,
         Assembly assembly,
         Type type,
         Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);

            else
                addWithLifeCycle(services, type);
        return services;
    }

}

