using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp1.Models;

public class Deudores
{
    [Key]
    public int DeudorId { get; set; }

    [Required(ErrorMessage = "La foto es obligatoria.")]
    public string? FotoCedulaURL { get; set; }

    [Required(ErrorMessage = "Favor ingresar la cédula.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "La cédula debe contener exactamente 11 dígitos numéricos.")]
    public string? NumeroCedula { get; set; }

    [Required(ErrorMessage = "Favor colocar los nombres.")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "Los nombres solo pueden contener letras.")]
    public string? Nombres { get; set; }

    [Required(ErrorMessage = "Favor colocar los apellidos.")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "Los apellidos solo pueden contener letras.")]
    public string? Apellidos { get; set; }

    [Required(ErrorMessage = "Favor colocar la dirección.")]
    [RegularExpression(@"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s,.#-]+$", ErrorMessage = "La dirección contiene caracteres no válidos.")]
    public string? Direccion { get; set; }

    [Required(ErrorMessage = "Favor colocar el teléfono.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe contener exactamente 10 dígitos.")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "Favor colocar la ciudad.")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "La ciudad solo puede contener letras.")]
    public string? Ciudad { get; set; }

    // Para que no sea un dato real directamente a la base de datos
    [NotMapped]
    public decimal? Saldo { get; set; }

    public virtual ICollection<Cobros> Cobros { get; set; }

    public virtual ICollection<Prestamos> Prestamos { get; set; } = new List<Prestamos>();
    public virtual ICollection<Garantias> Garantias { get; set; } = new List<Garantias>();

}
