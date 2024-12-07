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
                // Asegúrate de no asignar explícitamente el PrestamoId si es una columna IDENTITY
                // Si la relación es correcta, EF Core debería gestionar el PrestamoId automáticamente.
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
            // Logear o manejar el error
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

        // Eliminar los detalles de cobro asociados
        var detallesCobro = await contexto.cobrosDetalles
            .Where(cd => cd.CobroId == id)
            .ToListAsync();

        if (detallesCobro.Any())
        {
            contexto.cobrosDetalles.RemoveRange(detallesCobro);
        }

        // Ahora eliminar el cobro principal
        var cobro = await contexto.cobros
            .FirstOrDefaultAsync(c => c.CobroId == id);

        if (cobro != null)
        {
            contexto.cobros.Remove(cobro);
        }

        try
        {
            // Guardar los cambios
            var eliminado = await contexto.SaveChangesAsync();
            return eliminado > 0;
        }
        catch (Exception ex)
        {
            // Manejar cualquier error de eliminación
            Console.WriteLine($"Error al eliminar cobro: {ex.Message}");
            return false;
        }
    }

    //public async Task<bool> Eliminar(int id)
    //{
    //    await using var contexto = await DbFactory.CreateDbContextAsync();
    //    var eliminado = await contexto.cobros
    //        .Where(a => a.CobroId== id)
    //        .ExecuteDeleteAsync();
    //    return eliminado > 0;
    //}

    public async Task<Cobros?> Buscar(int cobroid)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.cobros
            .Include(c => c.CobrosDetalles) // Incluir detalles del cobro
            .ThenInclude(cd => cd.Prestamo) // Incluir el préstamo asociado a cada detalle
            .FirstOrDefaultAsync(c => c.CobroId == cobroid);
    }

    public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.cobros
            .Where(criterio)
            .Include(c => c.Deudor) // Solo incluye si es necesario
            .Include(c => c.CobrosDetalles)
            .AsNoTracking() // Mejora el rendimiento para consultas de solo lectura
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