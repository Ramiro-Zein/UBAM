using API_UBAM.DatabaseContext;
using API_UBAM.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_UBAM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlumnosController
{
    private readonly UbamDbContext _context;

    public AlumnosController(UbamDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlumnoDto>>> GetAlumnos()
    {
        return await _context.Alumnos
            .Include(c => c.Carrera)
            .Select(a => new AlumnoDto
            {
                Nombre = a.Persona.Nombre_Persona,
                Carrera = a.Carrera.Nombre_Carrera.ToString()
            })
            .ToListAsync();
    }
}