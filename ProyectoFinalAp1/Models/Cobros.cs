using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp1.Models;
public class Cobros
{
    [Key]
    public int CobroId { get; set; }

    [Required(ErrorMessage = "Favor seleccionar un deudor.")]
    [Range(1, int.MaxValue, ErrorMessage = "Favor seleccionar un deudor válido.")]
    public int DeudorId { get; set; }

    [ForeignKey("DeudorId")]
    public Deudores deudores { get; set; }

    [Required(ErrorMessage = "Favor seleccionar un préstamo.")]
    [Range(1, int.MaxValue, ErrorMessage = "Favor seleccionar un préstamo válido.")]
    public int PrestamoId { get; set; }

    [ForeignKey("PrestamoId")]
    public Prestamos Prestamo { get; set; }

    [Required(ErrorMessage = "Favor seleccionar un cobrador.")]
    public int CobradorId { get; set; } // Nueva propiedad de CobradorId

    [ForeignKey("CobradorId")]
    public Cobradores Cobrador { get; set; } // Relación con Cobradores

    public decimal? Mora { get; set; }

    [Required(ErrorMessage = "El importe a pagar es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El importe a pagar debe ser mayor a cero.")]
    public decimal ImportePagar { get; set; }

    [Required(ErrorMessage = "La fecha de prestamo es obligatorio.")]
    public DateTime FechaPrestamo { get; set; }

    [Required(ErrorMessage = "La fecha de cobro es obligatorio.")]
    public DateTime? FechaCobro { get; set; }

    public virtual ICollection<CobrosDetalle> CobrosDetalles { get; set; } = new List<CobrosDetalle>();
}