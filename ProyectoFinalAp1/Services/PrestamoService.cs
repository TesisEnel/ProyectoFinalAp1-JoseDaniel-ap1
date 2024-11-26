using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp1.Data;
using ProyectoFinalAp1.Models;
using System.Linq.Expressions;

namespace ProyectoFinalAp1.Services;

public class PrestamoService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int prestamoid)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.prestamos.AnyAsync(a => a.PrestamosId == prestamoid);
    }
    private async Task<bool> Insertar(Prestamos prestamo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.prestamos.Add(prestamo);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Prestamos prestamo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.prestamos.Update(prestamo);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Prestamos prestamo)
    {
        if (!await Existe(prestamo.PrestamosId))
            return await Insertar(prestamo);
        else
            return await Modificar(prestamo);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminado = await contexto.prestamos
            .Where(a => a.PrestamosId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }

    public async Task<Prestamos?> Buscar(int deudorid)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.prestamos
            .FirstOrDefaultAsync(a => a.PrestamosId == deudorid);
    }
    public async Task<List<Prestamos>> Listar(Expression<Func<Prestamos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.prestamos
            .Where(criterio)
            .ToListAsync();
    }
    public async Task<List<Prestamos>> ListarPrestamos()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.prestamos
            .AsNoTracking()
            .ToListAsync();
    }
}