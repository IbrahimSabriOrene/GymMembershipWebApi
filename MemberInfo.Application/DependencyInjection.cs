
using ErrorOr;
using FluentValidation;
using MediatR;
using MemberInfo.Application.Authentication.Commands.Register;
using MemberInfo.Application.Authentication.Common;
using MemberInfo.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;
namespace MemberInfo.Application;

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
