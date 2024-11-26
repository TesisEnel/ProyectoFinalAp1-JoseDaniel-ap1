using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp1.Data;
using ProyectoFinalAp1.Models;
using System.Linq.Expressions;

namespace ProyectoFinalAp1.Services;

public class FacturaService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int facturaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.abonos.AnyAsync(f => f.FacturaId == facturaId);
    }
    private async Task<bool> Insertar(Facturas factura)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.facturas.Add(factura);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Facturas factura)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.facturas.Update(factura);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Facturas factura)
    {
        if (!await Existe(factura.FacturaId))
            return await Insertar(factura);
        else
            return await Modificar(factura);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminado = await contexto.facturas
            .Where(f => f.FacturaId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }

    public async Task<Facturas?> Buscar(int facturaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.facturas
          .Include(f => f.DeudorId)
              .Include(f => f.PagoId)
                .Include(f => f.PrestamoId)
            .FirstOrDefaultAsync(f => f.FacturaId== facturaId);
    }
    public async Task<List<Facturas>> Listar(Expression<Func<Facturas, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.facturas
           .Include(f => f.DeudorId)
              .Include(f => f.PagoId)
                .Include(f => f.PrestamoId)
            .Where(criterio)
            .ToListAsync();
    }
    public async Task<List<Facturas>> ListarFacturas()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.facturas
            .AsNoTracking()
            .ToListAsync();
    }
}
