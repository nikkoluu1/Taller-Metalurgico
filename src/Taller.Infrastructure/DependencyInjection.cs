using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Taller.Infrastructure.Persistence;

namespace Taller.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Registra la base de datos y los servicios externos.
    /// </summary>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Taller")
            ?? throw new InvalidOperationException("Falta la cadena de conexión 'Taller'.");

        services.AddDbContext<TallerDbContext>(options => options.UseNpgsql(connectionString));

        services.AddHealthChecks()
            .AddDbContextCheck<TallerDbContext>("database", tags: ["ready"]);

        return services;
    }
}
