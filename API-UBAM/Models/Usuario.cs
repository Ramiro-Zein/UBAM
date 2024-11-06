using System.ComponentModel.DataAnnotations;

namespace API_UBAM.Models;

public class Usuario
{
    [Key] public Guid Id_Usuario { get; set; }

    [Required] public string Nombre_Usuario { get; set; }

    [Required] public string Clave_Usuario { get; set; }

    [Required] public Estatus Estatus_Usuario { get; set; }

    // Clave foránea y relación uno a uno con Persona
    [Required] public Guid Id_Persona { get; set; }
    public Persona Persona { get; set; }

    // Relación muchos a muchos con Rol
    public ICollection<UsuarioRol> Usuario_Roles { get; set; }

    public enum Estatus
    {
        Inactivo,
        Activo
    }
}