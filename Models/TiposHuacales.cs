using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jeremy_Sanchez_AP1_P1.Models;

public class TiposHuacales
{
    [Key]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "La descripcion es obligatoria")]
    public string Descripcion { get; set; } = string.Empty;

    [Range(0, int.MaxValue)]
    public int Existencia { get; set; }

    [ForeignKey("TipoId")]
    public ICollection<DetallesEntradas> DetallesEntradas { get; set; } = new List<DetallesEntradas>();
}
