using System.Text.Json.Serialization;

namespace WEB_UBAM.Models;

public class LoginRespuesta
{
    [JsonPropertyName("nombre_Completo")]
    public string Nombre_Completo { get; set; }

    [JsonPropertyName("roles")]
    public RolesRespuesta Roles { get; set; }
}

public class RolesRespuesta
{
    [JsonPropertyName("$values")]
    public List<string> Values { get; set; } = new List<string>();
}
