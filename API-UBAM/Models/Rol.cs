using System.ComponentModel.DataAnnotations;

namespace API_UBAM.Models;

public class Rol
{
    [Key] public Guid Id_Rol { get; set; }

    [Required] public string Nombre_Rol { get; set; }

    // Relación muchos a muchos con Usuario
    public ICollection<UsuarioRol> Usuario_Roles { get; set; }
}