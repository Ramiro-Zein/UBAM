using System.ComponentModel.DataAnnotations;

namespace API_UBAM.Models;

public class Rol
{
    [Key] public Guid Id_Rol { get; set; }

    [Required] public NombreRol Nombre_Rol { get; set; }

    // Relación muchos a muchos con Usuario
    public ICollection<Usuario_Rol> Usuario_Roles { get; set; }

    public enum NombreRol
    {
        Administrador,
        Docente,
        Alumno
    }
}