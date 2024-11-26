using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp1.Data;

namespace ProyectoFinalAp1.Services
{
    public class AbonoService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
       public async Task <bool>Existe(int AbonoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.abonos.AnyAsync(a => a.AbonoId == AbonoId);
        }
    }
}
