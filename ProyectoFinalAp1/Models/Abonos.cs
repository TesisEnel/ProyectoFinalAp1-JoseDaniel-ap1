using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp1.Models;

public class Abonos
{
    [Key]
    public int AbonoId { get; set; }

    [Required(ErrorMessage = "Favor seleccionar una factura.")]
    [Range(1, int.MaxValue, ErrorMessage = "Favor seleccionar una factura válida.")]
    public int FacturaId { get; set; }

    [ForeignKey("FacturaId")]
    public Facturas? Facturas { get; set; }

    [Required(ErrorMessage = "El monto del abono es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto del abono debe ser mayor a cero.")]
    public decimal? MontoAbono { get; set; }

    [Required(ErrorMessage = "La fecha del abono es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime? FechaAbono { get; set; }
}
