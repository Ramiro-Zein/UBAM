namespace WEB_UBAM.Models;

public class LoginRespuesta
{
    public string Nombre_Persona_Login_Respuesta { get; set; }
    public RolesRespuesta Roles_Login_Respuesta  { get; set; }
}

public class RolesRespuesta
{
    public List<string> Values { get; set; }
}
