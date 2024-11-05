using System.Text.Json.Serialization;

namespace WEB_UBAM.DTO;

public class PersonaDto
{
    public string NombrePersonaDto { get; set; }
    public string ApellidoPaternoPersonaDto { get; set; }
    public string ApellidoMaternoPersonaDto { get; set; }
    public DateOnly FechaNacimientoPersonaDto { get; set; }
    public string SexoPersonaDto { get; set; }
    public string CurpPersonaDto { get; set; }
    public RolesDto Roles { get; set; } 
}

public class RolesDto
{
    [JsonPropertyName("$values")]
    public List<string> Values { get; set; } = new List<string>();
}

