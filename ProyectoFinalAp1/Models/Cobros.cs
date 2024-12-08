using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp1.Models;
public class Cobros
{
    [Key]
    public int CobroId { get; set; }
    [Required(ErrorMessage = "Debe seleccionar un deudor.")]
    public int DeudorId { get; set; }
    [ForeignKey("DeudorId")]
    public virtual Deudores Deudor { get; set; }
    [Required(ErrorMessage = "Debe seleccionar un cobrador.")]
    public int CobradorId { get; set; } 

    [ForeignKey("CobradorId")]
    public Cobradores Cobrador { get; set; }
    [Required(ErrorMessage = "La mora si esta retrazado es obligatorio.")]
    [Range(0, double.MaxValue, ErrorMessage = "La mora no puede ser negativa.")]
    public decimal Mora { get; set; }
    [Required(ErrorMessage = "El importe a pagar es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El importe a pagar debe ser mayor que cero.")]
    public decimal ImportePagar { get; set; }
    [Required(ErrorMessage = "El campo Fecha de Préstamo es obligatorio.")]
    [DataType(DataType.Date, ErrorMessage = "La fecha de préstamo debe ser una fecha válida.")]
    public DateTime FechaPrestamo { get; set; }
    [Required(ErrorMessage = "El campo Fecha de Cobro es obligatorio.")]
    [DataType(DataType.Date, ErrorMessage = "La fecha de cobro debe ser una fecha válida.")]
    public DateTime FechaCobro { get; set; }
    public List<CobrosDetalle> CobrosDetalles { get; set; } = new List<CobrosDetalle>();
}