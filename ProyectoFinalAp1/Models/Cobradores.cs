using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp1.Models;
public class Cobradores
{
    //llave foreanea
    [Key]
    public int CobradorId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
    public string? Nombres { get; set; }
    [Required(ErrorMessage = "Favor colocar los apellidos.")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "Los apellidos solo pueden contener letras.")]
    public string? Apellidos { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "Debe ingresar un correo electrónico válido.")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Favor colocar la direccion es obligatoria.")]
    public string? Direccion { get; set; }
    [Required(ErrorMessage = "Favor seleccionar el estado.")]
    public string? Estado { get; set; }

    [Required(ErrorMessage = "La foto  de la cedula es obligatoria.")]
    public string? FotoCedulaURL { get; set; }

    [Required(ErrorMessage = "Favor ingresar el numero cédula.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "La cédula debe contener exactamente 11 dígitos numéricos.")]
    public string? NumeroCedula { get; set; }
    [Required(ErrorMessage = "Favor ingresar el telefono.")]
    public string? Telefono { get; set; }
    [Required(ErrorMessage = "Favor colocar la ciudad.")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "La ciudad solo puede contener letras.")]
    public string? Ciudad { get; set; }
    public virtual ICollection<Cobros> Cobros { get; set; } = new List<Cobros>();
}