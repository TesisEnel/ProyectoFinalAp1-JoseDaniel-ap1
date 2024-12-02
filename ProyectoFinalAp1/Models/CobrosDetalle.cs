using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAp1.Models;

public class CobrosDetalle
{
    [Key]
    public int DetalleId { get; set; }

    public int CobroId { get; set; }
    [ForeignKey("CobroId")]
    public Cobros cobros { get; set; }

    public int PrestamoId { get; set; }

    [ForeignKey("PrestamoId")]
    public Prestamos Prestamo { get; set; }

    public decimal ValorCobrado { get; set; }
}
