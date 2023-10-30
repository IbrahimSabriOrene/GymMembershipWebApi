using FluentValidation;
using MediatR;
using Customer.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;
namespace Customer.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
     cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssemblies(new[] { typeof(DependencyInjection).Assembly });
        return services;
    }
}
