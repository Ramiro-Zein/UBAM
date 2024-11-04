using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB_UBAM.Services;

namespace WEB_UBAM.Controllers;

[Authorize]
public class AlumnosController(AlumnosService alumnosService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var alumnos = await alumnosService.GetAlumno();
        return View(alumnos);
    }
}