using System.Security.Claims;
using API_UBAM.DatabaseContext;
using API_UBAM.DTO;
using API_UBAM.Interfaces;
using API_UBAM.Models;
using Microsoft.AspNetCore.Authentication;
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

    public async Task<UserDTO> ValidateUser(LoginSolicitarDto loginSolicitar)
    {
        var user = await _context.Usuarios
            .Include(u => u.Usuario_Roles)
                .ThenInclude(ur => ur.Rol)
            .FirstOrDefaultAsync(u => 
                u.Nombre_Usuario == loginSolicitar.Nombre_Usuario && 
                u.Estatus_Usuario == Usuario.Estatus.Activo);

        if (user == null)
        {
            return null;
        }

        if (!VerifyPassword(loginSolicitar.Clave_Usuario, user.Clave_Usuario))
        {
            return null;
        }

        var roles = user.Usuario_Roles
            .Select(ur => ur.Rol.Nombre_Rol)
            .ToList();

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Nombre_Usuario),
            new Claim(ClaimTypes.NameIdentifier, user.Id_Usuario.ToString()),
            new Claim("IdPersona", user.Id_Persona.ToString())
        };

        foreach (var rol in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, rol.ToString()));
        }

        var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        await _httpContextAccessor.HttpContext.SignInAsync(
            "CookieAuth",
            claimsPrincipal,
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddHours(8) // La sesión expira en 8 horas
            });
        
        return new UserDTO
        {
            Id_Usuario = user.Id_Usuario,
            Nombre_Usuario = user.Nombre_Usuario,
            Roles = roles,
            Id_Persona = user.Id_Persona
        };
    }

    public async Task SignOut()
    {
        if (_httpContextAccessor.HttpContext != null)
        {
            await _httpContextAccessor.HttpContext.SignOutAsync("CookieAuth");
        }
    }

    private bool VerifyPassword(string inputPassword, string storedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(inputPassword, storedPassword);
    }
}