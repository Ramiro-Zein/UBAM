using API_UBAM.Models;

namespace API_UBAM.DTO;

public class UserDTO
{
    public Guid Id_Usuario { get; set; }
    public string Nombre_Usuario { get; set; }
    public IEnumerable<Rol.NombreRol> Roles { get; set; }
    public Guid Id_Persona { get; set; }
}