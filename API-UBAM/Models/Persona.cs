using System.ComponentModel.DataAnnotations;

namespace API_UBAM.Models;

public class Persona
{
    [Key] public Guid Id_Persona { get; set; }

    [Required] public string Nombre_Persona { get; set; }

    [Required] public string Apellido_Paterno_Persona { get; set; }

    [Required] public string Apellido_Materno_Persona { get; set; }

    [Required] public DateOnly Fecha_Nacimiento_Persona { get; set; }

    [Required] public Sexo Sexo_Persona { get; set; }

    [Required] public string Curp_Persona { get; set; }

    // Relaciones uno a uno
    public Usuario Usuario { get; set; }
    public Alumno Alumno { get; set; }
    public Docente Docente { get; set; }

    public enum Sexo
    {
        Hombre,
        Mujer,
        [Display(Name = "No Definido")] NoDefinido
    }
}