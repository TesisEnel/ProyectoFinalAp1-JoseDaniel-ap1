using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp1.Data;
using ProyectoFinalAp1.Models;
using System.Linq.Expressions;

namespace ProyectoFinalAp1.Services;

public class GarantiaService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int garantiaid)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.garantias.AnyAsync(a => a.GarantiaId==garantiaid);
    }
    private async Task<bool> Insertar(Garantias garantia)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.garantias.Add(garantia);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Garantias garantia)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.garantias.Update(garantia);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Garantias garantia)
    {
        if (!await Existe(garantia.GarantiaId))
            return await Insertar(garantia);
        else
            return await Modificar(garantia);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminado = await contexto.garantias
            .Where(a => a.GarantiaId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }

    public async Task<Garantias?> Buscar(int garantiaid)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.garantias
            .FirstOrDefaultAsync(a => a.GarantiaId == garantiaid);
    }
    public async Task<List<Garantias>> Listar(Expression<Func<Garantias, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.garantias
            .Where(criterio)
            .Include(c => c.Prestamos)
            .Include(c => c.Deudores)
            .ToListAsync();
    }
    public async Task<List<Garantias>> Listargarantias()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.garantias
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> EliminarDetalles(List<int> detalleIds)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        try
        {
            var detalles = await contexto.garantiasDetalle
                .Where(d => detalleIds.Contains(d.DetalleId))
                .ToListAsync();

            if (detalles.Any())
            {
                contexto.garantiasDetalle.RemoveRange(detalles);
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

    public async Task<List<GarantiasDetalle>> ObtenerDetallesPorGarantiaId(int garantiaid)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.garantiasDetalle
     .Where(detalle => detalle.GarantiaId == garantiaid)
     .ToListAsync();
    }

}
