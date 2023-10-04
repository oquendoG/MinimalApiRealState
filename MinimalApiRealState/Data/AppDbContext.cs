using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MinimalApiRealState.Shared;

namespace MinimalApiRealState.Data;

public class AppDbContext : DbContext
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<RsProperty> Properties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.Entity<RsProperty>().HasData(
        new RsProperty
        {
            Id = Guid.NewGuid(),
            Name = "Casa las palmas",
            Description = "Descripción test 1",
            Location = "Cartagena",
            IsActive = true,
            CreationDate = DateTimeOffset.UtcNow
        },
        new RsProperty
        {
            Id = Guid.NewGuid(),
            Name = "Casa Concorde",
            Description = "Descripción test 2",
            Location = "Barranquilla",
            IsActive = true,
            CreationDate = DateTimeOffset.UtcNow
        },
        new RsProperty
        {
            Id = Guid.NewGuid(),
            Name = "Casa Centro Bogotá",
            Description = "Descripción test 3",
            Location = "Bogotá",
            IsActive = false,
            CreationDate = DateTimeOffset.UtcNow
        },
        new RsProperty
        {
            Id = Guid.NewGuid(),
            Name = "Casa El Poblado",
            Description = "Descripción test 4",
            Location = "Medellín",
            IsActive = true,
            CreationDate = DateTimeOffset.UtcNow
        });
    }
}
