using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp1.Models;

public class Pagos
{
    [Key]
    public int PagoId { get; set; }

    [Required(ErrorMessage = "Favor seleccionar un deudor.")]
    [Range(1, int.MaxValue, ErrorMessage = "Favor seleccionar un deudor válido.")]
    public int DeudorId { get; set; }

    [ForeignKey("DeudorId")]
    public Deudores? deudores { get; set; }

    [Required(ErrorMessage = "El monto del pago es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El Capital del pago debe ser mayor a cero.")]
    public decimal? Capital { get; set; }
    [Range(0.01, double.MaxValue, ErrorMessage = "El PagoPendiente del pago debe ser mayor a cero.")]
    public decimal? PagoPendiente { get; set; }

    [Required(ErrorMessage = "La fecha de pago es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime? FechaPago { get; set; }
}
