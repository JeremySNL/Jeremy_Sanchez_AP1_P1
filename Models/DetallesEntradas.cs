using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Jeremy_Sanchez_AP1_P1.Models;

public class DetallesEntradas
{
    [Key]
    public int DetalleId { get; set; }

    [Required(ErrorMessage = "La Entrada de huacales es obligatoria")]
    [Range(1, int.MaxValue, ErrorMessage = "Elija una entrada de huacales valida")]
    public int EntradaId { get; set; }

    [Required(ErrorMessage = "El Tipo de huacal es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "Elija un tipo de huacal valido")]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "La cantidad es obligatoria")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad no puede ser negativa")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio no puede ser negativo")]
    public decimal Precio { get; set; }
}
