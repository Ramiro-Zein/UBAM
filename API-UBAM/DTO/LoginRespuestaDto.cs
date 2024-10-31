using API_UBAM.Models;

namespace API_UBAM.DTO;

public class LoginRespuestaDto
{
    public string Nombre_Usuario { get; set; }
    public IEnumerable<Rol.NombreRol> Roles { get; set; }
}