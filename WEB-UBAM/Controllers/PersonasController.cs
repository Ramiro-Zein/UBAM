using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEB_UBAM.Controllers;

[Authorize(Policy = "Administrador")]
public class PersonasController : Controller
{
    public async Task<IActionResult> Index()
    {
        return View();
    }
}