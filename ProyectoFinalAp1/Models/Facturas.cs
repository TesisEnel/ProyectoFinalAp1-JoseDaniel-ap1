using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp1.Models;

public class Facturas
{
    [Key]
    public int FacturaId { get; set; }

    [Required(ErrorMessage = "Favor seleccionar un cliente.")]
    [Range(1, int.MaxValue, ErrorMessage = "Favor seleccionar un cliente válido.")]
    public int ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public Clientes? clientes { get; set; }
    [ForeignKey("PagoId")]
    public Pagos? pagos{ get; set; }

    [ForeignKey("PrestamoId")]
    public Prestamos? prestamos { get; set; }

    [Required(ErrorMessage = "El monto de la factura es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto de la factura debe ser mayor a cero.")]
    public decimal? MontoFactura { get; set; }

    [Required(ErrorMessage = "La fecha de emisión es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime? FechaEmision { get; set; }

    [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime? FechaVencimiento { get; set; }
}
