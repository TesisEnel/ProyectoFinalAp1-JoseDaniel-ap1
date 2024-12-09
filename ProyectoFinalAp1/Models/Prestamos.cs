using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp1.Models;
public class Prestamos
{
    [Key]
    public int PrestamoId { get; set; }
    public int DeudorId { get; set; }

    [ForeignKey("DeudorId")]
    public Deudores deudores { get; set; }

    [Required(ErrorMessage = "El monto prestado es obligatorio.")]
    [Range(1, (double)decimal.MaxValue, ErrorMessage = "El monto prestado debe ser mayor a 0.")]
    public decimal MontoPrestado { get; set; }

    [Required(ErrorMessage = "El interés es obligatorio.")]
    [Range(0.1, 100, ErrorMessage = "El interés debe estar entre 0.1% y 100%.")]
    public decimal? Interes { get; set; }

    [StringLength(250, ErrorMessage = "El concepto no puede exceder los 250 caracteres.")]
    public string? Concepto { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Las cuotas deben ser un número mayor a 0.")]
    public int? Cuotas { get; set; }

    [Required(ErrorMessage = "La forma de pago es obligatoria.")]
    [StringLength(50, ErrorMessage = "La forma de pago no puede exceder los 50 caracteres.")]
    public string? FormaPago { get; set; }

    public DateTime? FechaPrestamo { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido.")]
    public DateTime? FechaCobro { get; set; }

    [Range(0, (double)decimal.MaxValue, ErrorMessage = "El monto por cuota debe ser un valor positivo.")]
    public decimal? MontoCuota { get; set; }

    [Range(0, (double)decimal.MaxValue, ErrorMessage = "El total de interés debe ser un valor positivo.")]
    public decimal? TotalInteres { get; set; }

    [Range(0, (double)decimal.MaxValue, ErrorMessage = "El monto total a pagar debe ser un valor positivo.")]
    public decimal? MontoTotalPagar { get; set; }

    [Range(0, (double)decimal.MaxValue, ErrorMessage = "El saldo debe ser un valor positivo.")]
    public decimal? Saldo { get; set; }

    [StringLength(20, ErrorMessage = "El estado no puede exceder los 20 caracteres.")]
    public string? Estado { get; set; }

    public virtual ICollection<Cobros> Cobros { get; set; } = new List<Cobros>();
    public virtual ICollection<Garantias> Garantias { get; set; } = new List<Garantias>();
    public List<CobrosDetalle> CobrosDetalles { get; set; } = new List<CobrosDetalle>();
    public decimal InteresValue => Interes ?? 0m;
    public decimal MontoCuotaValue => MontoCuota ?? 0m;
}