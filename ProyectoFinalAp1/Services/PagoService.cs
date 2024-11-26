using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp1.Data;

namespace ProyectoFinalAp1.Services
{
    public class PagoService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
    }
}
