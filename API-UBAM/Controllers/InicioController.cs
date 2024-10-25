using Microsoft.AspNetCore.Mvc;

namespace API_UBAM.Controllers;

[ApiController]
[Route("")]
public class InicioController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Bienvenido");
    }
}