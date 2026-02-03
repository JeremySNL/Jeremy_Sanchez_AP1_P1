using Jeremy_Sanchez_AP1_P1.DAL;
using Jeremy_Sanchez_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Jeremy_Sanchez_AP1_P1.Services;

public class ViajesEspacialesService(IDbContextFactory<Contexto> DbFactory)
{
    /*public async Task<bool> Guardar(ViajesEspaciales viajeEspacial)
    {

    }

    public async Task<bool> Existe(ViajesEspaciales viajeEspacial)
    {

    }
    public async Task<bool> Insertar(ViajesEspaciales viajeEspacial)
    {

    }
    public async Task<bool> Modificar(ViajesEspaciales viajeEspacial)
    {

    }
    public async Task<bool> Buscar(int viajeId)
    {

    }
    public async Task<bool> Eliminar(int viajeId)
    {
        
    }*/
    public async Task<List<ViajesEspaciales>> Listar(Expression<Func<ViajesEspaciales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ViajesEspaciales.Where(criterio).AsNoTracking().ToListAsync();
    }
}

