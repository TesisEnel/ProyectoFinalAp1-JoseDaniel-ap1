using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp1.Models;

namespace ProyectoFinalAp1.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
         : base(options)
    {  }

    public DbSet<Abonos> abonos{ get; set; }
    public DbSet<Pagos> pagos{ get; set; }
    public DbSet<Cobros> cobros{ get; set; }
    public DbSet<Facturas> facturas{ get; set; }
    public DbSet<Deudores> deudores { get; set; }
    public DbSet<Prestamos> prestamos { get; set; }
}


