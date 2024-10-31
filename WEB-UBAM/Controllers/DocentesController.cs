using Microsoft.AspNetCore.Mvc;
using WEB_UBAM.Services;

namespace WEB_UBAM.Controllers;

public class DocentesController : Controller
{
    private readonly DocentesService _docentesService;

    public DocentesController(DocentesService docentesService)
    {
        _docentesService = docentesService;
    }

    public async Task<IActionResult> Index()
    {
        var docentes = await _docentesService.GetDocentes();
        return View(docentes);
    }
}