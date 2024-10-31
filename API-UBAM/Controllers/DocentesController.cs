using API_UBAM.DatabaseContext;
using API_UBAM.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_UBAM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocentesController : Controller
{
    private readonly UbamDbContext _context;

    public DocentesController(UbamDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DocenteDTO>>> GetDocentes()
    {
        var docentes = await _context.Docentes
            .Select(d => new DocenteDTO
            {
                NombreDocente = d.Persona.Nombre_Persona + " " + d.Persona.Apellido_Paterno_Persona + " " + d.Persona.Apellido_Materno_Persona
            })
            .ToListAsync();
        
        return Ok(docentes);
    }
}