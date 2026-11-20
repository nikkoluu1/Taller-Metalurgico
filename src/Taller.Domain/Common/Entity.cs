namespace Taller.Domain.Common;

/// <summary>
/// Clase base para todas las entidades del dominio.
/// </summary>
public abstract class Entity
{
    public Guid Id { get; protected set; } = Guid.CreateVersion7();
}
