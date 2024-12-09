using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp1.Models;
public class GarantiasDetalle
{
    [Key]
    public int DetalleId { get; set; }
    public int GarantiaId { get; set; }
    [ForeignKey("GarantiaId")]
    public Garantias Garantia { get; set; }
    [Required(ErrorMessage = "El nombre del artículo es requerido.")]
    public string? Articulo { get; set; }
    [Required(ErrorMessage = "La cantidad es obligatoria.")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
    public int Cantidad { get; set; }
    [Required(ErrorMessage = "La cantidad es obligatoria.")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
    public decimal? ValorUnitario { get; set; }
    [NotMapped]
    [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor que cero.")]
    public decimal? Total { get; set; }
    [Required(ErrorMessage = "Favor proporcionar un enlace válido para la foto del detalle.")]
    [Url(ErrorMessage = "El enlace proporcionado no es válido.")]
    public string? FotoDetalleUrl { get; set; }  
}