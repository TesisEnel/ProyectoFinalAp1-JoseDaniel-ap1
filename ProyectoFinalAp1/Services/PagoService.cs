using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp1.Data;
using ProyectoFinalAp1.Models;
using System.Linq.Expressions;

namespace ProyectoFinalAp1.Services;

public class PagoService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int pagoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.pagos.AnyAsync(p =>p.PagoId==pagoId);
    }
    private async Task<bool> Insertar(Pagos pago)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.pagos.Add(pago);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Pagos pago)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.pagos.Update(pago);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Pagos pago)
    {
        if (!await Existe(pago.PagoId))
            return await Insertar(pago);
        else
            return await Modificar(pago);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminado = await contexto.pagos
            .Where(p => p.PagoId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }

    public async Task<Pagos?> Buscar(int pagoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.pagos
          .Include(p => p.DeudorId)
            .FirstOrDefaultAsync(p => p.PagoId == pagoId);
    }
    public async Task<List<Pagos>> Listar(Expression<Func<Pagos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.pagos
           .Include(p => p.DeudorId)
            .Where(criterio)
            .ToListAsync();
    }
    public async Task<List<Pagos>> ListarPagos()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.pagos
            .AsNoTracking()
            .ToListAsync();
    }
}
