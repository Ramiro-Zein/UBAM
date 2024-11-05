using API_UBAM.DatabaseContext;
using API_UBAM.DTO;
using API_UBAM.Models;
using API_UBAM.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_UBAM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonasController(UbamDbContext context) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> GetPersona()
    {
        var personas = await context.Personas
            .Include(p => p.Usuario.Usuario_Roles)
            .ThenInclude(ur => ur.Rol)
            .Select(p => new PersonaDto
            {
                NombrePersonaDto = p.Nombre_Persona,
                ApellidoPaternoPersonaDto = p.Apellido_Paterno_Persona,
                ApellidoMaternoPersonaDto = p.Apellido_Materno_Persona,
                FechaNacimientoPersonaDto = p.Fecha_Nacimiento_Persona,
                SexoPersonaDto = p.Sexo_Persona.ToString(),
                CurpPersonaDto = p.Curp_Persona,
                Roles = p.Usuario.Usuario_Roles.Select(ur => ur.Rol.Nombre_Rol.ToString()).ToList()
            })
            .ToListAsync();

        return Ok(personas);
    }
    
}