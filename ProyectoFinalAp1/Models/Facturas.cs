using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp1.Models;
public class Facturas
{
    [Key]
    public int FacturaId { get; set; }
    [Required(ErrorMessage = "Favor seleccionar un deudor.")]
    [Range(1, int.MaxValue, ErrorMessage = "Favor seleccionar un deudor válido.")]
    public int DeudorId { get; set; }
    [ForeignKey("DeudorId")]
    public Deudores? deudores { get; set; }
    [Required(ErrorMessage = "Favor seleccionar un préstamo.")]
    [Range(1, int.MaxValue, ErrorMessage = "Favor seleccionar un préstamo válido.")]
    public int PrestamoId { get; set; }
    [ForeignKey("PrestamoId")]
    public Prestamos? prestamos { get; set; }
    [Required(ErrorMessage = "El monto de la factura es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto de la factura debe ser mayor a cero.")]
    public decimal? MontoFactura { get; set; }
    [Required(ErrorMessage = "La fecha de emisión es obligatoria.")]
    [DataType(DataType.Date, ErrorMessage = "La fecha de emisión debe ser una fecha válida.")]
    public DateTime? FechaEmision { get; set; }
    [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
    [DataType(DataType.Date, ErrorMessage = "La fecha de vencimiento debe ser una fecha válida.")]
    public DateTime? FechaVencimiento { get; set; }
}
