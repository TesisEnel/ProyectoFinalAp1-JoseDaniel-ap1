using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp1.Models;
public class Sucursales
{
    [Key]
    public int SucursalId { get; set; }

    [Required(ErrorMessage = "El nombre de la sucursal es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre de la sucursal no puede exceder los 100 caracteres.")]
    public string NombreSucursal { get; set; }

    [Required(ErrorMessage = "La dirección es obligatoria.")]
    [StringLength(200, ErrorMessage = "La dirección no puede exceder los 200 caracteres.")]
    public string Direccion { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "El número de teléfono no tiene un formato válido.")]
    public string Telefono { get; set; }

    [Required(ErrorMessage = "El estado es obligatorio.")]
    public string Estado { get; set; }

    [Required(ErrorMessage = "La fecha de emisión es obligatoria.")]
    [DataType(DataType.Date, ErrorMessage = "La fecha de emisión debe ser una fecha válida.")]
    public DateTime? FechaEmision { get; set; }

    [Required(ErrorMessage = "Favor proporcionar un enlace válido para la foto del detalle.")]
    [Url(ErrorMessage = "El enlace proporcionado no es válido.")]
    public string FotoSucursalUrl { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un deudor.")]
    [Range(1, int.MaxValue, ErrorMessage = "Seleccione un deudor válido.")]
    public int DeudorId { get; set; }

    [ForeignKey("DeudorId")]
    public Deudores? deudores { get; set; }
    public ICollection<Cobros> Cobros { get; set; } = new List<Cobros>();
}