using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp1.Models;

namespace ProyectoFinalAp1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }

        public DbSet<Cobros> cobros { get; set; }
        public DbSet<Facturas> facturas { get; set; }
        public DbSet<Deudores> deudores { get; set; }
        public DbSet<Prestamos> prestamos { get; set; }
        public DbSet<Cobradores> cobradores { get; set; }
        public DbSet<Garantias> garantias { get; set; }
        public DbSet<CobrosDetalle> cobrosDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cobros>()
                .HasOne(c => c.Deudor)
                .WithMany()
                .HasForeignKey(c => c.DeudorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cobros>()
                .HasMany(c => c.CobrosDetalles)
                .WithOne(cd => cd.Cobro)
                .HasForeignKey(cd => cd.CobroId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cobros>()
                .HasOne(c => c.Prestamo)
                .WithMany(p => p.Cobros)
                .HasForeignKey(c => c.PrestamoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Facturas>()
                .HasOne(f => f.deudores)
                .WithMany()
                .HasForeignKey(f => f.DeudorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Facturas>()
                .HasOne(f => f.prestamos)
                .WithMany()
                .HasForeignKey(f => f.PrestamoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Garantias>()
                .HasOne(g => g.Prestamos)
                .WithMany(p => p.Garantias)
                .HasForeignKey(g => g.PrestamoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Garantias>()
                .HasOne(g => g.Deudores)
                .WithMany(d => d.Garantias)
                .HasForeignKey(g => g.DeudorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CobrosDetalle>()
    .HasOne(cd => cd.Prestamo)
    .WithMany()  // Si es una relación uno a muchos
    .HasForeignKey(cd => cd.PrestamoId)
    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}