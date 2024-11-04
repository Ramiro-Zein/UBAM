using API_UBAM.DatabaseContext;
using API_UBAM.DTO;
using API_UBAM.Models;
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
            .Select(p => new PersonaDto
            {
                Nombre = p.Nombre_Persona,
                ApellidoPaterno = p.Apellido_Paterno_Persona,
                ApellidoMaterno = p.Apellido_Materno_Persona,
                FechaNacimiento = p.Fecha_Nacimiento_Persona,
                //Sexo = p.Sexo_Persona,
                Curp = p.Curp_Persona
            })
            .ToListAsync();

        return personas;
    }
}