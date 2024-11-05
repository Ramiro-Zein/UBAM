using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_UBAM.Models;

public class Docente
{
    [Key] public Guid Id_Docente { get; set; }

    // Clave foránea y relación uno a uno con Persona
    [Required] public Guid Id_Persona { get; set; }
    public Persona Persona { get; set; }
}