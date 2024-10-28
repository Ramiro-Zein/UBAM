using Microsoft.AspNetCore.Mvc;

namespace WEB_UBAM.Controllers;

public class AlumnosController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}