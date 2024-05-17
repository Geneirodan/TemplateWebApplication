using System.Reflection;
using Common.Mediator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Profiles.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
        services
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true)
            .AddMediatRPipeline(Assembly.GetExecutingAssembly());
}