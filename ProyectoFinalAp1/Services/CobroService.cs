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
    public async Task<bool> Insertar(Cobros cobro)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        try
        {
            foreach (var detalle in cobro.CobrosDetalles)
            {
                if (detalle.PrestamoId != 0)
                {
                    detalle.Prestamo = await contexto.prestamos.FindAsync(detalle.PrestamoId);
                }
            }
            contexto.cobros.Add(cobro);
            await contexto.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
    private async Task<bool> Modificar(Cobros cobro)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.cobros.Update(cobro);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> EliminarDetalles(List<int> detalleIds)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        try
        {
            var detalles = await contexto.cobrosDetalles
                .Where(d => detalleIds.Contains(d.DetalleId))
                .ToListAsync();
            if (detalles.Any())
            {
                contexto.cobrosDetalles.RemoveRange(detalles);
                await contexto.SaveChangesAsync();
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar detalles: {ex.Message}");
            return false;
        }
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
        var detallesCobro = await contexto.cobrosDetalles
            .Where(cd => cd.CobroId == id)
            .ToListAsync();
        if (detallesCobro.Any())
        {
            contexto.cobrosDetalles.RemoveRange(detallesCobro);
        }
        var cobro = await contexto.cobros
            .FirstOrDefaultAsync(c => c.CobroId == id);
        if (cobro != null)
        {
            contexto.cobros.Remove(cobro);
        }

        try
        {
            var eliminado = await contexto.SaveChangesAsync();
            return eliminado > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar cobro: {ex.Message}");
            return false;
        }
    }
    public async Task<Cobros?> Buscar(int cobroid)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.cobros
            .Include(c => c.CobrosDetalles) 
            .ThenInclude(cd => cd.Prestamo)
            .FirstOrDefaultAsync(c => c.CobroId == cobroid);
    }
    public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.cobros
            .Where(criterio)
            .Include(c => c.Deudor) 
            .Include(c => c.CobrosDetalles)
            .AsNoTracking() 
            .ToListAsync();
    }
    public async Task<List<Cobros>> ListarCobros()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.cobros
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<List<CobrosDetalle>> ObtenerCobrosDetallePorDeudor(int deudorId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.cobrosDetalles
            .Include(cd => cd.Cobro)
            .Include(cd => cd.Prestamo)
            .Where(cd => cd.Cobro.DeudorId == deudorId)
            .ToListAsync();
    }

    public async Task<List<Cobros>> ObtenerCobrosPorDeudor(int deudorId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.cobros
            .Where(c => c.DeudorId == deudorId)
            .ToListAsync();
    }


}