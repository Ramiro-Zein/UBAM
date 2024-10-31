using Microsoft.AspNetCore.Mvc;
using WEB_UBAM.Services;

namespace WEB_UBAM.Controllers;

public class AlumnosController : Controller
{
    private readonly AlumnosService _alumnosService;

    public AlumnosController(AlumnosService alumnosService)
    {
        _alumnosService = alumnosService;
    }

    public async Task<IActionResult> Index()
    {
        var alumnos = await _alumnosService.GetAlumno();
        return View(alumnos);
    }
}