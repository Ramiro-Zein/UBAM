using System.Security.Claims;
using API_UBAM.DatabaseContext;
using API_UBAM.Interfaces;
using API_UBAM.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace API_UBAM.Services;

public class AuthService : IAuthService
{
    private readonly UbamDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(UbamDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> ValidarUsuario(string nombreUsuario, string clave)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Nombre_Usuario == nombreUsuario && u.Estatus_Usuario == Usuario.Estatus.Activo);

        if (usuario == null || !BCrypt.Net.BCrypt.Verify(clave, usuario.Clave_Usuario)) return false;

        // Configurar cookies de autenticación
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, usuario.Nombre_Usuario) };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

        return true;
    }

    public async Task CerrarSesion()
    {
        await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
