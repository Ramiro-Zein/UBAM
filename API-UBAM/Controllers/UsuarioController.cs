using API_UBAM.DatabaseContext;
using API_UBAM.DTO;
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
    

    [HttpPost]
    public async Task<ActionResult> CreateUsuario([FromBody] UsuarioDTO nuevoUsuarioDto)
    {
        var personaExiste = await _context.Personas.AnyAsync(p => p.Id_Persona == nuevoUsuarioDto.Id_Persona);
        if (!personaExiste) return BadRequest("La persona especificada no existe.");

        var nuevoUsuario = new Usuario
        {
            Id_Usuario = Guid.NewGuid(),
            Nombre_Usuario = nuevoUsuarioDto.Nombre_Usuario,
            Clave_Usuario = BCrypt.Net.BCrypt.HashPassword(nuevoUsuarioDto.Clave_Usuario),
            Id_Persona = nuevoUsuarioDto.Id_Persona,
            Estatus_Usuario = Usuario.Estatus.Activo,
            Usuario_Roles = nuevoUsuarioDto.Ids_Roles
                .Select(idRol => new UsuarioRol { Id_Usuario = Guid.NewGuid(), Id_Rol = idRol })
                .ToList()
        };

        _context.Usuarios.Add(nuevoUsuario);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUsuario), new { id = nuevoUsuario.Id_Usuario }, nuevoUsuario);
    }

    [HttpPost("asignar-rol")]
    public async Task<ActionResult> AsignarRol([FromBody] AsignarRolDTO asignarRolDto)
    {
        var usuario = await _context.Usuarios.FindAsync(asignarRolDto.Id_Usuario);
        if (usuario == null) return NotFound("Usuario no encontrado.");

        var rol = await _context.Roles.FindAsync(asignarRolDto.Id_Rol);
        if (rol == null) return NotFound("Rol no encontrado.");

        var existeRol = await _context.UsuarioRoles
            .AnyAsync(ur => ur.Id_Usuario == asignarRolDto.Id_Usuario && ur.Id_Rol == asignarRolDto.Id_Rol);
        if (existeRol) return BadRequest("El rol ya está asignado a este usuario.");

        var usuarioRol = new UsuarioRol
        {
            Id_Usuario = asignarRolDto.Id_Usuario,
            Id_Rol = asignarRolDto.Id_Rol
        };

        _context.UsuarioRoles.Add(usuarioRol);
        await _context.SaveChangesAsync();

        return Ok("Rol asignado correctamente.");
    }


}