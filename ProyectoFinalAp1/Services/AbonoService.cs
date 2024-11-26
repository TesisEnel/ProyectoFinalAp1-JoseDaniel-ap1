using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp1.Data;
using ProyectoFinalAp1.Models;
using static Azure.Core.HttpHeader;
using System.Linq.Expressions;

namespace ProyectoFinalAp1.Services;

public class AbonoService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
   public async Task <bool>Existe(int AbonoId)
   {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.abonos.AnyAsync(a => a.AbonoId == AbonoId);
   }
    private async Task<bool> Insertar(Abonos abono)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.abonos.Add(abono);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Abonos abono)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.abonos.Update(abono);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Abonos abono)
    {
        if (!await Existe(abono.AbonoId))
            return await Insertar(abono);
        else
            return await Modificar(abono);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminado = await contexto.abonos
            .Where(a => a.AbonoId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }

    public async Task<Abonos?> Buscar(int abonoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.abonos
          .Include(a => a.FacturaId)
            .FirstOrDefaultAsync(a => a.AbonoId == abonoId);
    }
    public async Task<List<Abonos>> Listar(Expression<Func<Abonos, bool>> Criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.abonos
            .Include(a => a.FacturaId)
            .Where(Criterio)
            .ToListAsync();
    }
    public async Task<List<Abonos>> ListarAbonos()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.abonos
            .AsNoTracking()
            .ToListAsync();
    }
}
