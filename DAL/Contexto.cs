using Jeremy_Sanchez_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace Jeremy_Sanchez_AP1_P1.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<EntradasHuacales> EntradasHuacales { get; set; }
    public DbSet<DetallesEntradas> DetallesEntradas { get; set; }
    public DbSet<TiposHuacales> TiposHuacales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        modelBuilder.Entity<TiposHuacales>().HasData(new List<TiposHuacales>()
        {
            new TiposHuacales() { TipoId = 1, Descripcion = "Huacales Verdes" },
            new TiposHuacales() { TipoId = 2, Descripcion = "Huacales Rojos" },
            new TiposHuacales() { TipoId = 3, Descripcion = "Huacales Amarillos" }
        });
        base.OnModelCreating(modelBuilder);
    }
}

