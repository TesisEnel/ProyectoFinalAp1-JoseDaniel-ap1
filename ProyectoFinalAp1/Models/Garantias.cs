using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp1.Models;

public class Garantias
{
    [Key]
    public int GarantiaId { get; set; }

    [Required(ErrorMessage = "Favor seleccionar el tipo de garantía del mismo")]
    public string? TipoGarantia { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "El valor de la garantía debe ser mayor que cero.")]
    public decimal? ValorGarantia { get; set; }

    [Required(ErrorMessage = "Favor colocar la fecha de garantía de su deudor.")]
    public DateTime FechaGarantia { get; set; }

    // Nueva propiedad para almacenar el enlace de la foto
    [Required(ErrorMessage = "Favor proporcionar un enlace válido para la foto de la garantía.")]
    [Url(ErrorMessage = "El enlace proporcionado no es válido.")]
    public string? FotoGarantiaUrl { get; set; }

    // Relación con Deudores
    public int DeudorId { get; set; }

    [ForeignKey("DeudorId")]
    public Deudores Deudores { get; set; }

    // Relación con Préstamos
    public int PrestamoId { get; set; }

    [ForeignKey("PrestamoId")]
    public Prestamos? Prestamos { get; set; }
}
