using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp1.Data;
using ProyectoFinalAp1.Models;
using System.Linq.Expressions;

namespace ProyectoFinalAp1.Services;

public class CobroService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int cobroid)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.cobros.AnyAsync(a => a.CobroId == cobroid);
    }
    private async Task<bool> Insertar(Cobros cobro)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.cobros.Add(cobro);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Cobros cobro)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.cobros.Update(cobro);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Cobros cobro)
    {
        if (!await Existe(cobro.CobroId))
            return await Insertar(cobro);
        else
            return await Modificar(cobro);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminado = await contexto.cobros
            .Where(a => a.CobroId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }

    public async Task<Cobros?> Buscar(int cobroid)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.cobros
            .FirstOrDefaultAsync(a => a.CobroId == cobroid);
    }
    public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.cobros
            .Where(criterio)
            .Include(c => c.CobrosDetalles)
            .Include(c => c.Deudor)
               .Include(c => c.Prestamo)
            .ToListAsync();
    }
    public async Task<List<Cobros>> ListarCobros()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.cobros
            .AsNoTracking()
            .ToListAsync();
    }
}