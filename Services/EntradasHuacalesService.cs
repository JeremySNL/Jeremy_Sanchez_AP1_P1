using Jeremy_Sanchez_AP1_P1.DAL;
using Jeremy_Sanchez_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Jeremy_Sanchez_AP1_P1.Services;

public class EntradasHuacalesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(EntradasHuacales entradaHuacal)
    {
        foreach (var detalle in entradaHuacal.DetallesEntradas)
        {
            Console.WriteLine(detalle.EntradaId + " - " + detalle.DetalleId + " - " + detalle.Cantidad + " - " + detalle.Precio);
        }
        if (!await Existe(entradaHuacal.EntradaId))
        {
            return await Insertar(entradaHuacal);
        }
        else
        {
            return await Modificar(entradaHuacal);
        }
    }

    public async Task<bool> Existe(int EntradaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.AnyAsync(e => e.EntradaId == EntradaId);
    }
    public async Task<bool> Insertar(EntradasHuacales entradaHuacal)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Add(entradaHuacal);
        await AfectarTiposHuacales(contexto, entradaHuacal.DetallesEntradas.ToArray(), TipoOperacion.Suma);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Modificar(EntradasHuacales entradaHuacal)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var entradaVieja = await contexto.EntradasHuacales
            .Include(e => e.DetallesEntradas)
            .FirstOrDefaultAsync(e => e.EntradaId == entradaHuacal.EntradaId);

        if (entradaVieja == null) return false;

        await AfectarTiposHuacales(contexto, entradaVieja.DetallesEntradas.ToArray(), TipoOperacion.Resta);

        entradaVieja.DetallesEntradas.Clear();
        foreach (var detalle in entradaHuacal.DetallesEntradas)
        {
            entradaVieja.DetallesEntradas.Add(detalle);
        }

        await AfectarTiposHuacales(contexto, entradaVieja.DetallesEntradas.ToArray(), TipoOperacion.Suma);

        // Actualizar propiedades
        entradaVieja.Fecha = entradaHuacal.Fecha;
        entradaVieja.NombreCliente = entradaHuacal.NombreCliente;
        entradaVieja.Cantidad = entradaHuacal.Cantidad;
        entradaVieja.Precio = entradaHuacal.Precio;

        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task AfectarTiposHuacales(Contexto contexto, DetallesEntradas[] detalles, TipoOperacion tipoOperacion)
    {
        foreach (var detalle in detalles)
        {
            var tipo = await contexto.TiposHuacales.FirstOrDefaultAsync(t => t.TipoId == detalle.TipoId);
            if (tipo != null)
            {
                if (tipoOperacion == TipoOperacion.Suma)
                    tipo.Existencia += detalle.Cantidad;
                else if (tipoOperacion == TipoOperacion.Resta)
                    tipo.Existencia -= detalle.Cantidad;
            }
        }
    }
    public async Task<EntradasHuacales?> Buscar(int EntradaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.Include(e => e.DetallesEntradas).FirstOrDefaultAsync(e => e.EntradaId == EntradaId);
    }
    public async Task<bool> Eliminar(int EntradaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var entradaHuacales = await contexto.EntradasHuacales
            .Include(e => e.DetallesEntradas)
            .FirstOrDefaultAsync(e => e.EntradaId == EntradaId);

        if (entradaHuacales == null) return false;

        // Restar existencias de los detalles
        await AfectarTiposHuacales(contexto, entradaHuacales.DetallesEntradas.ToArray(), TipoOperacion.Resta);

        // Eliminar la entrada (y en cascada los detalles si está configurado)
        contexto.EntradasHuacales.Remove(entradaHuacales);

        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<List<EntradasHuacales>> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.Where(criterio).AsNoTracking().ToListAsync();
    }
}
public enum TipoOperacion
{
    Suma = 1,
    Resta = 2
}