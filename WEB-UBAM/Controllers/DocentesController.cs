using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB_UBAM.Services;

namespace WEB_UBAM.Controllers;

[Authorize(Policy = "Administrador")]
public class DocentesController(DocentesService docentesService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var docentes = await docentesService.GetDocentes();
        return View(docentes);
    }
}