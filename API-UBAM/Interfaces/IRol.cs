using API_UBAM.Models;

namespace API_UBAM.Interfaces;

public interface IRol
{
    Guid Id_Rol { get; set; }
    Rol.NombreRol Nombre_Rol { get; set; }
    ICollection<Usuario_Rol> Usuario_Roles { get; set; }
}