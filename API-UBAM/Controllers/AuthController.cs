using API_UBAM.DTO;
using API_UBAM.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_UBAM.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> Login([FromBody] LoginSolicitarDto solicitar)
    {
        try
        {
            var userInfo = await _authService.ValidateUser(solicitar);
            return Ok(userInfo);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor: " + ex.Message });
        }
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _authService.SignOut();
        return Ok(new { message = "Sesión cerrada exitosamente" });
    }
}