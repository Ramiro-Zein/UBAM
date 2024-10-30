using API_UBAM.DatabaseContext;
using API_UBAM.DTO;
using API_UBAM.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_UBAM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlumnosController : ControllerBase
{
    private readonly UbamDbContext _context;

    public AlumnosController(UbamDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlumnoDto>>> GetAlumnos()
    {
        DisplayNameConverter display = new DisplayNameConverter();
        var alumnos = await _context.Alumnos
            .Select(a => new AlumnoDto
            {
                Nombre_Alumno = a.Persona.Nombre_Persona,
                Carrera_Alumno = display.ConvertDisplay(a.Carrera.Nombre_Carrera.ToString()),
                FechaNacimiento_Alumno = a.Persona.Fecha_Nacimiento_Persona
            })
            .ToListAsync();

        return Ok(alumnos);
    }
}