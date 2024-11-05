using API_UBAM.DatabaseContext;
using API_UBAM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_UBAM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : Controller
{
    private readonly UbamDbContext _context;

    public UsuarioController(UbamDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> GetUsuario()
    {
        var usuarios = await _context.Usuarios
            .Include(u => u.Usuario_Roles)
            .ThenInclude(ur => ur.Rol)
            .Select(u => new 
            {
                u.Nombre_Usuario,
                Roles = u.Usuario_Roles.Select(ur => ur.Rol.Nombre_Rol.ToString())
            })
            .ToListAsync();

        return Ok(usuarios);
    }

}