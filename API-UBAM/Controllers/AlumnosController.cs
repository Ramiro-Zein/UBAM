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
                NombreAlumno = a.Persona.Nombre_Persona + " " + a.Persona.Apellido_Paterno_Persona + " " + a.Persona.Apellido_Materno_Persona,
                CarreraAlumno = display.ConvertDisplay(a.Carrera.Nombre_Carrera.ToString()),
                GrupoAlumno = a.Persona.Alumno.Grupo_Alumno,
                FechaNacimientoAlumno = a.Persona.Fecha_Nacimiento_Persona
            })
            .ToListAsync();

        return Ok(alumnos);
    }
}