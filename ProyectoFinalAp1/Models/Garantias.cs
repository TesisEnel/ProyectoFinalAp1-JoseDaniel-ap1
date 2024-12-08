using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp1.Models;
public class Garantias
{
    [Key]
    public int GarantiaId { get; set; }
    public decimal? ValorGarantia { get; set; }
    [Required(ErrorMessage = "Favor colocar la fecha de garantía de su deudor.")]
    [DataType(DataType.Date, ErrorMessage = "La fecha ingresada debe tener un formato válido.")]
    public DateTime FechaGarantia { get; set; }
    [Required(ErrorMessage = "Debe seleccionar un deudor.")]
    public int DeudorId { get; set; }
    [ForeignKey("DeudorId")]
    public Deudores Deudores { get; set; }
    [Required(ErrorMessage = "Debe seleccionar un préstamo.")]
    public int PrestamoId { get; set; }
    [ForeignKey("PrestamoId")]
    public Prestamos? Prestamos { get; set; }
    public ICollection<GarantiasDetalle> Detalles { get; set; } = new List<GarantiasDetalle>();
    [NotMapped]
    [Range(0, double.MaxValue, ErrorMessage = "El total de la garantía debe ser mayor o igual a cero.")]
    public decimal Total => Detalles?.Sum(d => d.Total) ?? 0;
}