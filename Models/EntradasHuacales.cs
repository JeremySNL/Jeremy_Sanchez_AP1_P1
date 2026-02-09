using System.ComponentModel.DataAnnotations;

namespace Jeremy_Sanchez_AP1_P1.Models;

public class EntradasHuacales
{
    [Key]
    public int IdEntrada { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "El nombre del cliente es obligatoria")]
    [StringLength(75, ErrorMessage = "El nombre del cliente tiene un maximo de 75 ")]
    public String NombreCliente { get; set; } = String.Empty;

    [Required(ErrorMessage = "La cantidad es obligatoria")]
    [Range(1, Int32.MaxValue, ErrorMessage = "La cantidad no puede ser negativa")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "El costo es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio no puede ser negativo")]
    public decimal Precio { get; set; }
}