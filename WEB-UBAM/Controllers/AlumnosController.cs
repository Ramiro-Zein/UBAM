using Microsoft.AspNetCore.Mvc;

namespace WEB_UBAM.Controllers;

public class AlumnosController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public JsonResult GetAlumnos()
    {
        var alumnos = new List<object>
        {
            new { Id = 1, Nombre = "Juan Perez", Carrera = "Ingeniería en Sistemas", Edad = 22 },
            new { Id = 2, Nombre = "Ana García", Carrera = "Licenciatura en Matemáticas", Edad = 21 },
            new { Id = 3, Nombre = "Carlos López", Carrera = "Ingeniería Industrial", Edad = 23 }
        };

        return Json(alumnos);
    }
}