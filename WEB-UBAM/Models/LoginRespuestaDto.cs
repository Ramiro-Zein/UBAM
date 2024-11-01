namespace WEB_UBAM.Models;

public class LoginRespuestaDto
{
    public string Mensaje_Login_Respuesta { get; set; }
    public string Nombre_Persona_Login_Respuesta { get; set; }
    public IEnumerable<string> Roles_Login_Respuesta { get; set; }
}