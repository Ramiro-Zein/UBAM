using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB_UBAM.Services;

namespace WEB_UBAM.Controllers;

[Authorize(Policy = "Administrador")]
public class PersonasController(PersonasService personasService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var personas = await personasService.GetPersonas();
        return View(personas);
    }
}