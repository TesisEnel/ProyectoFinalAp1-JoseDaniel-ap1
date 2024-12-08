using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp1.Models;
public class CobrosDetalle
{
    [Key]
    [Required(ErrorMessage = "Debe seleccionar un préstamo válido.")]
    [Range(1, int.MaxValue, ErrorMessage = "El PrestamoId no puede ser 0.")]
    public int DetalleId { get; set; }
    [Required(ErrorMessage = "Debe asociar el detalle a un cobro válido.")]
    [Range(1, int.MaxValue, ErrorMessage = "El CobroId debe ser un valor mayor que 0.")]
    public int CobroId { get; set; } 
    [Required(ErrorMessage = "Debe asociar el detalle a un préstamo válido.")]
    [Range(1, int.MaxValue, ErrorMessage = "El PrestamoId debe ser un valor mayor que 0.")]
    public int PrestamoId { get; set; } 

    [Required(ErrorMessage = "El Valor Cobrado es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El Valor Cobrado debe ser mayor que 0.")]
    public decimal? ValorCobrado { get; set; }
    [ForeignKey("CobroId")]
    public virtual Cobros Cobro { get; set; } = new Cobros();
    [ForeignKey("PrestamoId")]
    public Prestamos Prestamo { get; set; } = new Prestamos();
}