using System.Text.Json.Serialization;

namespace WEB_UBAM.Models;

public class LoginRespuesta
{
    public string Mensaje { get; set; }
    public string Bienvenida { get; set; }
    public string Nombre_Completo { get; set; }
    public List<string> Roles { get; set; } = new List<string>();
}
