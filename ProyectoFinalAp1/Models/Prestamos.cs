using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp1.Models;
public class Prestamos
{
    [Key]
    [Required(ErrorMessage = "El ID del préstamo es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "El ID del préstamo debe ser válido.")]
    public int PrestamoId { get; set; }
    [Required(ErrorMessage = "Favor seleccionar un deudor.")]
    [Range(1, int.MaxValue, ErrorMessage = "Favor seleccionar un deudor válido.")]
    public int DeudorId { get; set; }
    [ForeignKey("DeudorId")]
    public Deudores? deudores { get; set; }
    [Required(ErrorMessage = "El monto prestado es obligatorio.")]
    [Range(1, (double)decimal.MaxValue, ErrorMessage = "El monto prestado debe ser mayor a 0.")]
    public decimal? MontoPrestado { get; set; }
    [Required(ErrorMessage = "El interés es obligatorio.")]
    [Range(0.1, 100, ErrorMessage = "El interés debe estar entre 0.1% y 100%.")]
    public decimal? Interes { get; set; }
    [Required(ErrorMessage = "El concepto es obligatorio.")]
    public string? Concepto { get; set; }
    [Required(ErrorMessage = "El número de cuotas es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "El número de cuotas debe ser mayor a 0.")]
    public int? Cuotas { get; set; }
    [Required(ErrorMessage = "La forma de pago es obligatoria.")]
    [StringLength(50, ErrorMessage = "La forma de pago no puede exceder los 50 caracteres.")]
    public string? FormaPago { get; set; }
    [Required(ErrorMessage = "La fecha del préstamo es obligatoria.")]
    [DataType(DataType.Date, ErrorMessage = "La fecha debe ser válida.")]
    public DateTime? FechaPrestamo { get; set; }
    [Required(ErrorMessage = "La fecha de cobro es obligatoria.")]
    [DataType(DataType.Date, ErrorMessage = "La fecha debe ser válida.")]
    public DateTime? FechaCobro { get; set; }
    [Required(ErrorMessage = "El monto por cuota es obligatorio.")]
    [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "El monto por cuota debe ser mayor a 0.")]
    public decimal? MontoCuota { get; set; }
    [Required(ErrorMessage = "El total de interés es obligatorio.")]
    [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "El total de interés debe ser mayor a 0.")]
    public decimal? TotalInteres { get; set; }
    [Required(ErrorMessage = "El monto total a pagar es obligatorio.")]
    [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "El monto total a pagar debe ser mayor a 0.")]
    public decimal? MontoTotalPagar { get; set; }
    [Range(0, (double)decimal.MaxValue, ErrorMessage = "El saldo debe ser un valor positivo.")]
    public decimal? Saldo { get; set; }
    [Required(ErrorMessage = "El estado es obligatorio.")]
    public string? Estado { get; set; }
    public virtual ICollection<Cobros> Cobros { get; set; }
    public virtual ICollection<Garantias> Garantias { get; set; }
    public List<CobrosDetalle> CobrosDetalles { get; set; } = new List<CobrosDetalle>();
}