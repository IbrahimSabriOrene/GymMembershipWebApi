using MemberInfo.Api.Common.Errors;
using MemberInfo.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MemberInfo.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        //services.AddControllers(options => options.Filters.Add<ErrorsHandlingFeatureAttribute>());
        services.AddControllers();
        services.AddMappings();
        services.AddSingleton<ProblemDetailsFactory , CustomProblemDetailsFactory>();
       return services;
    }
}
