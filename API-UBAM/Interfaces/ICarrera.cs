using API_UBAM.Models;

namespace API_UBAM.Interfaces;

public interface ICarrera
{
    Guid Id_Carrera { get; set; }
    Carrera.NombreCarrera Nombre_Carrera { get; set; }
    ICollection<Alumno> Alumnos { get; set; }
}