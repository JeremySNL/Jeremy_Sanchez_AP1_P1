using Jeremy_Sanchez_AP1_P1.DAL;
using Jeremy_Sanchez_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace Jeremy_Sanchez_AP1_P1.Services;

public class TiposHuacalesServices(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<List<TiposHuacales>> Listar()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales.Where(t => t.TipoId > 0).ToListAsync();
    }
}
