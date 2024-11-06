using API_UBAM.Models;

namespace API_UBAM.Interfaces;

public interface IRol
{
    Guid Id_Rol { get; set; }
    string Nombre_Rol { get; set; }
    ICollection<UsuarioRol> Usuario_Roles { get; set; }
}