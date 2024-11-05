using API_UBAM.Models;

namespace API_UBAM.DTO;

public class LoginRespuestaDto
{
    public string Nombre_Persona_Login_Respuesta { get; set; }
    public IEnumerable<string> Roles_Login_Respuesta { get; set; }
}