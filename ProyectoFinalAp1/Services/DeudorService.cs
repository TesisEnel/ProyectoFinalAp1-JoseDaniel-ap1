using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp1.Data;
using ProyectoFinalAp1.Models;
using System.Linq.Expressions;

namespace ProyectoFinalAp1.Services;

public class DeudorService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int deudorid)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.deudores.AnyAsync(a => a.DeudorId == deudorid);
    }
    private async Task<bool> Insertar(Deudores deudor)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.deudores.Add(deudor);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Deudores deudor)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.deudores.Update(deudor);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Deudores deudor)
    {
        if (!await Existe(deudor.DeudorId))
            return await Insertar(deudor);
        else
            return await Modificar(deudor);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminado = await contexto.deudores
            .Where(a => a.DeudorId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }

    public async Task<Deudores?> Buscar(int deudorid)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.deudores
            .FirstOrDefaultAsync(a => a.DeudorId == deudorid);
    }
    public async Task<List<Deudores>> Listar(Expression<Func<Deudores, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.deudores
            .Where(criterio)
            .ToListAsync();
    }
    public async Task<List<Deudores>> ListarDeudores()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.deudores
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<Deudores?> ObtenerDeudorePorId(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.deudores.FirstOrDefaultAsync(c => c.DeudorId == id);
    }

    public async Task<List<Deudores>> ObtenerTodos()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.deudores.ToListAsync();
    }

    public async Task<List<Deudores>> ObtenerDeudoreConPrestamos()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.deudores
            .Where(c => c.Prestamos.Any())
            .ToListAsync();
    }
}