using API_UBAM.Models;

namespace API_UBAM.DTO;

public class UsuarioDTO
{
    public string Nombre_Usuario { get; set; }
    public string Clave_Usuario { get; set; }
    public Guid Id_Persona { get; set; }
    public List<Guid> Ids_Roles { get; set; }
}
