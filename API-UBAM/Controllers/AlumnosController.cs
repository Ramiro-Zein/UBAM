using API_UBAM.DatabaseContext;
using API_UBAM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_UBAM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlumnosController : ControllerBase
{
    private readonly UbamDbContext _context;

    public AlumnosController(UbamDbContext dbContext)
    {
        _context = dbContext;
    }

    // GET: api/Alumnos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Alumno>>> GetAlumnos() => await _context.Alumnos.ToListAsync();
}