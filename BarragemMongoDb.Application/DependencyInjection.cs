using BarragemMongoDb.Application.Services;
using BarragemMongoDb.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BarragemMongoDb.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices
        (this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddScoped<IBarragemService, BarragemService>();

        return services;
    }
}
