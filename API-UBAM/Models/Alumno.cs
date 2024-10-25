using System.ComponentModel.DataAnnotations;

namespace API_UBAM.Models;

public class Alumno
{
    public Guid Id_Alumno { get; set; }
    public string Grupo_Alumno { get; set; }
}