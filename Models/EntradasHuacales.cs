using System.ComponentModel.DataAnnotations;

namespace Jeremy_Sanchez_AP1_P1.Models;

public class EntradasHuacales
{
    [Key]
    public int ViajeId { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "La descripcion es obligatoria")]
    [StringLength(200, ErrorMessage = "La descripcion tiene un maximo de 200 ")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "El costo es obligatorio")]
    public double Costo { get; set; }
}