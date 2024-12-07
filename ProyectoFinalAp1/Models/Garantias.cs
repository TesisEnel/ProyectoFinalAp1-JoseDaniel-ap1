using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp1.Models;

public class Garantias
{
    [Key]
    public int GarantiaId { get; set; }


    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "El valor de la garantía debe ser mayor que cero.")]
    public decimal ValorGarantia { get; set; }

    [Required(ErrorMessage = "Favor colocar la fecha de garantía de su deudor.")]
    public DateTime FechaGarantia { get; set; }

    // Relación con Deudores
    public int DeudorId { get; set; }

    [ForeignKey("DeudorId")]
    public Deudores Deudores { get; set; }

    // Relación con Préstamos
    public int PrestamoId { get; set; }

    [ForeignKey("PrestamoId")]
    public Prestamos? Prestamos { get; set; }

    // Relación con Detalles de Garantía
    public ICollection<GarantiasDetalle> Detalles { get; set; } = new List<GarantiasDetalle>();

    // Cálculo del total de la garantía (suma de los totales de los detalles)
    public decimal Total => Detalles?.Sum(d => d.Total) ?? 0;

}