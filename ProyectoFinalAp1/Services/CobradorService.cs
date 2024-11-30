using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp1.Data;
using ProyectoFinalAp1.Models;
using System.Linq.Expressions;

namespace ProyectoFinalAp1.Services;

public class CobradorService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int Cobradorid)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.cobradores.AnyAsync(a => a.CobradorId== Cobradorid);
    }
    private async Task<bool> Insertar(Cobradores cobrador)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.cobradores.Add(cobrador);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Cobradores cobrador)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.cobradores.Update(cobrador);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Cobradores cobrador)
    {
        if (!await Existe(cobrador.CobradorId))
            return await Insertar(cobrador);
        else
            return await Modificar(cobrador);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminado = await contexto.cobradores
            .Where(a => a.CobradorId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }

    public async Task<Cobradores?> Buscar(int Cobradorid)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.cobradores
            .FirstOrDefaultAsync(a => a.CobradorId == Cobradorid);
    }
    public async Task<List<Cobradores>> Listar(Expression<Func<Cobradores, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.cobradores
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
    public async Task<List<Cobradores>> ListarCobradores()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.cobradores
            .AsNoTracking()
            .ToListAsync();
    }
}
