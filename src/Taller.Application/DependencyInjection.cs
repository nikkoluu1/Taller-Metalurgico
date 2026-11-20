using Microsoft.Extensions.DependencyInjection;

namespace Taller.Application;

public static class DependencyInjection
{
    /// <summary>
    /// Registra los casos de uso de la capa de aplicación.
    /// </summary>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
