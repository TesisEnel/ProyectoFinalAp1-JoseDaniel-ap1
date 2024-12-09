using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp1.Data;
using ProyectoFinalAp1.Models;
using System.Linq.Expressions;

namespace ProyectoFinalAp1.Services;

public class SucursalService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int sucursalid)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.sucursales.AnyAsync(a => a.SucursalId == sucursalid);
    }
    private async Task<bool> Insertar(Sucursales sucursal)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.sucursales.Add(sucursal);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Sucursales sucursal)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.sucursales.Update(sucursal);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Sucursales sucursal)
    {
        if (!await Existe(sucursal.SucursalId))
            return await Insertar(sucursal);
        else
            return await Modificar(sucursal);
    }
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminado = await contexto.sucursales
            .Where(a => a.SucursalId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    public async Task<Sucursales?> Buscar(int sucursalid)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.sucursales
            .AsNoTracking()
            .Include(a => a.deudores)
            .FirstOrDefaultAsync(a => a.SucursalId == sucursalid);
    }
    public async Task<List<Sucursales>> Listar(Expression<Func<Sucursales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.sucursales
            .Where(criterio)
            .AsNoTracking()
            .Include(s => s.deudores)
            .ToListAsync();
    }
    public async Task<List<Sucursales>> ListarSucursal()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.sucursales
            .AsNoTracking()
            .ToListAsync();
    }
}