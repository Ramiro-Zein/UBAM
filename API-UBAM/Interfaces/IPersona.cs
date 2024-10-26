using API_UBAM.Models;

namespace API_UBAM.Interfaces;

public interface IPersona
{
    Guid Id_Persona { get; set; }
    string Nombre_Persona { get; set; }
    string Apellido_Paterno_Persona { get; set; }
    string Apellido_Materno_Persona { get; set; }
    DateOnly Fecha_Nacimiento_Persona { get; set; }
    Persona.Sexo Sexo_Persona { get; set; }
    string Curp_Persona { get; set; }
    Usuario Usuario { get; set; }
    Alumno Alumno { get; set; }
    Docente Docente { get; set; }
}