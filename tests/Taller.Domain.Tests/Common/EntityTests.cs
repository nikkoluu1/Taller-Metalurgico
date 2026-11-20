using Taller.Domain.Common;

namespace Taller.Domain.Tests.Common;

public class EntityTests
{
    private sealed class EntidadDePrueba : Entity;

    [Fact]
    public void Cada_entidad_nueva_recibe_un_id_distinto()
    {
        var a = new EntidadDePrueba();
        var b = new EntidadDePrueba();

        Assert.NotEqual(Guid.Empty, a.Id);
        Assert.NotEqual(a.Id, b.Id);
    }
}
