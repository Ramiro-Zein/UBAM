﻿using API_UBAM.Models;

namespace API_UBAM.DTO;

public class PersonaDto
{
    public string NombrePersonaDto { get; set; }
    public string ApellidoPaternoPersonaDto { get; set; }
    public string ApellidoMaternoPersonaDto { get; set; }
    public DateOnly FechaNacimientoPersonaDto { get; set; }
    public string SexoPersonaDto { get; set; }
    public string CurpPersonaDto { get; set; }
    public List<string> Roles { get; set; } 
}
