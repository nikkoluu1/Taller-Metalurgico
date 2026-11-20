using Microsoft.EntityFrameworkCore;

namespace Taller.Infrastructure.Persistence;

public class TallerDbContext(DbContextOptions<TallerDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplica todas las configuraciones IEntityTypeConfiguration de este ensamblado.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TallerDbContext).Assembly);
    }
}
