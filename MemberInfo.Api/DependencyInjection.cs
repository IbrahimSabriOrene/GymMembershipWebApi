using Customer.Api.Common.Errors;
using Customer.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Customer.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        //services.AddControllers(options => options.Filters.Add<ErrorsHandlingFeatureAttribute>());
        services.AddControllers();
        services.AddMappings();
        services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "Customer.Api", Version = "v1" });
        });
        return services;
    }
}
