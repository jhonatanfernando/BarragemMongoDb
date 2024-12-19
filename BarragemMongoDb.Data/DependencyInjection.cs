using BarragemMongoDb.Data.Repositories;
using BarragemMongoDb.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BarragemMongoDb.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories
        (this IServiceCollection services)
    {
        services.AddScoped<IBarragemRepository, BarragemRepository>();

        return services;
    }
}
