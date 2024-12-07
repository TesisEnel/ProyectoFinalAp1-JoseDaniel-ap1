using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp1.Models;

public class CobrosDetalle
{
    [Key]



    [Required(ErrorMessage = "Debe seleccionar un préstamo válido.")]
    [Range(1, int.MaxValue, ErrorMessage = "El PrestamoId no puede ser 0.")]
    public int DetalleId { get; set; }

    public int CobroId { get; set; } // Clave foránea hacia Cobros
    // No asignes PrestamoId manualmente
    public int PrestamoId { get; set; } // Clave foránea hacia Prestamos

    [Required(ErrorMessage = "El Valor Cobrado es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El Valor Cobrado debe ser mayor que 0.")]
    public decimal ValorCobrado { get; set; }

    // Propiedades de navegación
    [ForeignKey("CobroId")]

    public virtual Cobros Cobro { get; set; } = new Cobros();
    [ForeignKey("PrestamoId")]

    public Prestamos Prestamo { get; set; } = new Prestamos();
   
}