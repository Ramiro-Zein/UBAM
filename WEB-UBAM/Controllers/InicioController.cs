using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEB_UBAM.Controllers;

[Authorize]
public class InicioController(ILogger<InicioController> logger) : Controller
{
    private readonly ILogger<InicioController> _logger = logger;

    public IActionResult Index()
    {
        var nombreCompleto = User.Identity?.Name;
        var roles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

        ViewBag.NombreCompleto = nombreCompleto;
        ViewBag.Roles = roles;

        return View();
    }
}