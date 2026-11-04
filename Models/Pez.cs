using System.ComponentModel.DataAnnotations;

namespace AcuarioMvc.Models;

public class Pez
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; } = "";

    [Required(ErrorMessage = "Seleccione el tipo de agua")]
    [Display(Name = "Tipo de agua")]
    public string TipoAgua { get; set; } = "";

    [Range(1, 100, ErrorMessage = "La cantidad debe estar entre 1 y 100")]
    public int Cantidad { get; set; }

    public DateTime FechaRegistro { get; set; }
}
