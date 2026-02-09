using Jeremy_Sanchez_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace Jeremy_Sanchez_AP1_P1.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<EntradasHuacales> EntradasHuacales { get; set; }
}

