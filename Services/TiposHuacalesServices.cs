using Jeremy_Sanchez_AP1_P1.DAL;
using Jeremy_Sanchez_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace Jeremy_Sanchez_AP1_P1.Services;

public class TiposHuacalesServices(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(TiposHuacales tipoHuacales)
    {
        if (!await Existe(tipoHuacales.TipoId))
        {
            return await Insertar(tipoHuacales);
        }
        else
        {
            return await Modificar(tipoHuacales);
        }
    }

    public async Task<bool> Existe(int TipoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales.AnyAsync(t => t.TipoId == TipoId);
    }
    public async Task<bool> Insertar(TiposHuacales tipoHuacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.TiposHuacales.Add(tipoHuacales);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Modificar(TiposHuacales tipoHuacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.TiposHuacales.Update(tipoHuacales);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<List<TiposHuacales>> Listar()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales.Where(t => t.TipoId > 0).ToListAsync();
    }
}
