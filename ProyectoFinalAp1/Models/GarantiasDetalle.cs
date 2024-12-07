using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp1.Models
{
    public class GarantiasDetalle
    {
        public int DetalleId { get; set; }

        [Required]
        public int GarantiaId { get; set; }

        [ForeignKey("GarantiaId")]
        public Garantias Garantia { get; set; }

        [Required(ErrorMessage = "El nombre del artículo es requerido.")]
        public string? Articulo { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El valor unitario es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El valor debe ser mayor que cero.")]
        public decimal ValorUnitario { get; set; }

        // Cálculo del total (Cantidad * ValorUnitario)
        public decimal Total { get; set; }

        [Required(ErrorMessage = "Favor proporcionar un enlace válido para la foto del detalle.")]
        [Url(ErrorMessage = "El enlace proporcionado no es válido.")]
        public string? FotoDetalleUrl { get; set; }  // Foto del detalle de la garantía
    }
}
