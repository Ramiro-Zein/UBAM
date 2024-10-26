using API_UBAM.Models;

namespace API_UBAM.Interfaces;

public interface IAlumno
{
    Guid Id_Alumno { get; set; }
    string Grupo_Alumno { get; set; }
    Guid Id_Persona { get; set; }
    Persona Persona { get; set; }
    Guid Id_Carrera { get; set; }
    Carrera Carrera { get; set; }
}