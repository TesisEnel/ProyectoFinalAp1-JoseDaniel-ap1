using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp1.Models;

public class CobrosDetalle
{
    [Key]
    public int DetalleId { get; set; }

    public int CobroId { get; set; } // Clave foránea hacia Cobros
    public int PrestamoId { get; set; } // Clave foránea hacia Prestamos

    public decimal ValorCobrado { get; set; }

    // Propiedades de navegación
    [ForeignKey("CobroId")]
    public virtual Cobros Cobro { get; set; }

    [ForeignKey("PrestamoId")]
    public Prestamos Prestamo { get; set; }
}