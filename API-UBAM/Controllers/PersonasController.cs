﻿using API_UBAM.DatabaseContext;
using API_UBAM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_UBAM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonasController : Controller
{
    private readonly UbamDbContext _context;

    public PersonasController(UbamDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Persona>>> GetPersona()
    {
        return await _context.Personas
            .Include(u => u.Usuario)
            .Include(a => a.Alumno)
            .Include(d => d.Docente)
            .ToListAsync();
    }
}