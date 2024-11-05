using Microsoft.AspNetCore.Mvc;

namespace WEB_UBAM.Controllers;

public class NotFoundController : Controller
{
    public async Task<IActionResult>  Index()
    {
        return View();
    }
}