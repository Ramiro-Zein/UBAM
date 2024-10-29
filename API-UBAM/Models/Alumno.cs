using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_UBAM.Models;

public class Alumno
{
    [Key] public Guid Id_Alumno { get; set; }

    [Required] public string Grupo_Alumno { get; set; }

    // Clave foránea y relación uno a uno con Persona
    [Required] [JsonIgnore] public Guid Id_Persona { get; set; }
    public Persona Persona { get; set; }

    // Clave foránea y relación muchos a uno con Carrera
    [Required] [JsonIgnore] public Guid Id_Carrera { get; set; }
    public Carrera Carrera { get; set; }
}