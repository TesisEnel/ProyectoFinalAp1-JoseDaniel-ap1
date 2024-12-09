using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp1.Models;

public class Cobros
{
    [Key]
    public int CobroId { get; set; }

    public int DeudorId { get; set; }
    [ForeignKey("DeudorId")]

    public virtual Deudores Deudor { get; set; }

    public int CobradorId { get; set; } 

    [ForeignKey("CobradorId")]
    public Cobradores Cobrador { get; set; }

    public int PrestamoId { get; set; }
   
    public decimal ImporteAPagar { get; set; }
    public decimal Mora { get; set; }
    [Required(ErrorMessage = "El campo Fecha de Cobro es obligatorio.")]
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaCobro { get; set; }

    public List<CobrosDetalle> CobrosDetalles { get; set; } = new List<CobrosDetalle>();
}