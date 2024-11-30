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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cobros>()
          .HasKey(c => c.CobroId);

        // Configurar relación entre Cobros y Deudores
        modelBuilder.Entity<Cobros>()
            .HasOne(c => c.deudores)
            .WithMany()
            .HasForeignKey(c => c.DeudorId)
            .OnDelete(DeleteBehavior.Restrict); // Evitar cascada

        // Configurar relación entre Cobros y Prestamos
        modelBuilder.Entity<Cobros>()
            .HasOne(c => c.Prestamo)
             .WithMany(p => p.Cobros)
            .HasForeignKey(c => c.PrestamoId)
            .OnDelete(DeleteBehavior.Restrict); // Evitar cascada

        // Configurar relación entre Facturas y Deudores
        modelBuilder.Entity<Facturas>()
            .HasOne(f => f.deudores)
            .WithMany()
            .HasForeignKey(f => f.DeudorId)
            .OnDelete(DeleteBehavior.Restrict); // Evitar cascada

        // Configurar relación entre Facturas y Prestamos
        modelBuilder.Entity<Facturas>()
            .HasOne(f => f.prestamos)
            .WithMany()
            .HasForeignKey(f => f.PrestamoId)
            .OnDelete(DeleteBehavior.Restrict); // Evitar cascada

        // Configurar relación entre Facturas y Pagos
        modelBuilder.Entity<Facturas>()
            .HasOne(f => f.pagos)
            .WithMany()
            .HasForeignKey(f => f.PagoId)
            .OnDelete(DeleteBehavior.Restrict); // Evitar cascada
    }
}