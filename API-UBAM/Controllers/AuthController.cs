using API_UBAM.DatabaseContext;
using API_UBAM.DTO;
using API_UBAM.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_UBAM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService, UbamDbContext context) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginSolicitarDto respuesta)
    {
        if (!await authService.ValidarUsuario(respuesta.Nombre_Usuario, respuesta.Clave_Usuario))
            return Unauthorized("Credenciales incorrectas");

        var usuario = await context.Usuarios
            .Include(u => u.Usuario_Roles)
            .ThenInclude(ur => ur.Rol)
            .Include(u => u.Persona)
            .FirstOrDefaultAsync(u =>
                EF.Functions.Collate(u.Nombre_Usuario, "Latin1_General_BIN") == respuesta.Nombre_Usuario);

        if (usuario == null) return Unauthorized("Credenciales incorrectas");

        var respuestaDto = new LoginRespuestaDto
        {
            Nombre_Persona_Login_Respuesta = usuario.Persona.Nombre_Persona + " " +
                                             usuario.Persona.Apellido_Paterno_Persona + " " +
                                             usuario.Persona.Apellido_Materno_Persona,
            Roles_Login_Respuesta = usuario.Usuario_Roles.Select(ur => ur.Rol.Nombre_Rol.ToString()).ToList()
        };

        return Ok(new
        {
            Mensaje = "Usuario autenticado",
            Nombre_Completo = respuestaDto.Nombre_Persona_Login_Respuesta,
            Roles = respuestaDto.Roles_Login_Respuesta
        });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await authService.CerrarSesion();
        return Ok("Sesión cerrada.");
    }
}